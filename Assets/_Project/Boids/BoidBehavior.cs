using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehavior : MonoBehaviour
{
    public Vector3 velocity;
    public float maxVelocity;

    // Start is called before the first frame update
    void Start()
    {
        velocity = this.transform.forward * maxVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (velocity.magnitude > maxVelocity)
        {
            velocity = velocity.normalized * maxVelocity;
        }

        this.transform.position += velocity * Time.deltaTime;
        this.transform.rotation = Quaternion.LookRotation(velocity);

        //move towards center of mass of other boids
    }

    
}
