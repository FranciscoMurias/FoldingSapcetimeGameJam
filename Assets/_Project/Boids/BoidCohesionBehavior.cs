using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[RequireComponent(typeof(BoidBehavior))]

//find other nearby boids and merge together
public class BoidCohesionBehavior : MonoBehaviour
{
    private BoidBehavior baseBoid;

    public float radius;
    
    // Start is called before the first frame update
    void Start()
    {
        baseBoid = GetComponent<BoidBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        var listOfOtherBoids = FindObjectsOfType<BoidBehavior>();
        var average = Vector3.zero;
        var numFound = 0;

        foreach (var boid in listOfOtherBoids.Where(b => b != baseBoid))
        {
            var diff = boid.transform.position - this.transform.position;
            if (diff.magnitude < radius)
            {
                average += diff;
                numFound += 1;
            }
        }

        if (numFound > 0)
        {
            average = average / numFound;

            //move everything towards that average
            baseBoid.velocity += Vector3.Lerp(Vector3.zero, average, average.magnitude / radius);
        }
            

    }
}
