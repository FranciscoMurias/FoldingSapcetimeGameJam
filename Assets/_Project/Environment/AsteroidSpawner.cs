using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    private int numAsteroids;

    private float asteroidSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        numAsteroids = Random.Range(10, 15);

        for (int i = 0; i < numAsteroids; i++)
        {
            Vector3 randomPoint = Random.insideUnitSphere * (Random.Range(-400f, 400f));
            Vector3 randVelocity = Random.insideUnitSphere * (Random.Range(-10f, 10f));
            
            GameObject asteroid = Instantiate(asteroidPrefab, randomPoint, Random.rotation);
            asteroid.GetComponent<Rigidbody>().AddForce(randVelocity * asteroidSpeed, ForceMode.VelocityChange);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
