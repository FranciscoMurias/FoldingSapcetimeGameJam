using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour
{
    private Flock agentFlock;
    public Flock AgentFlock
    {
        get { return agentFlock; }
    }
    
    private Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } }

    [SerializeField] private GameObject explosionParticles;
    public EnemyManager managerRef;
    public ObjectPoolBehaviour projectileObjectPool;
    public Transform projectileSpawnTransform;

    private float nextShot = 0.0f;
    private float shootRate = 0.0f;

    private int smallShotMax = 5;
    private int smallShotCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider>();
        shootRate = Random.Range(0.5f, 2.0f);
    }

    public void initialize(Flock flock)
    {
        agentFlock = flock;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 velocity)
    {
        transform.forward = velocity;
        transform.position += velocity * Time.deltaTime;
    }

    public void Die()
    {
        managerRef.GetEnemyDeathNotification(gameObject);
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        //spawn destruction particle effect here
        gameObject.SetActive(false);
    }

    void ShootProjectile()
    {
        GameObject newProjectile = projectileObjectPool.GetPooledObject();
        newProjectile.transform.position = projectileSpawnTransform.position;
        newProjectile.transform.rotation = projectileSpawnTransform.rotation;
        newProjectile.SetActive(true);

    }

    public void CalculateShootingLogic()
    {
        Debug.Log("Enemy Trying to shoot");

        if (smallShotCounter > smallShotMax)
        {
            if (Time.time > nextShot)
            {
                ShootProjectile();
                nextShot = Time.time + shootRate;
            }
        }
        else
        {
            smallShotCounter++;
        }
        
    }
}
