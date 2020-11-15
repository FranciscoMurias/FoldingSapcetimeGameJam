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

    public EnemyManager managerRef;

    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider>();
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
        //spawn destruction particle effect here
        gameObject.SetActive(false);
    }
}
