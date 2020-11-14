using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(BoidBehavior))]
public class BoidContainerBehavoir : MonoBehaviour
{
    private BoidBehavior baseBoid;

    public float radius;

    public float boundaryForce;

    // Start is called before the first frame update
    void Start()
    {
        baseBoid = GetComponent<BoidBehavior>();
    }


    // Update is called once per frame
    void Update()
    {
        if (baseBoid.transform.position.magnitude > radius)
        {
            baseBoid.velocity += this.transform.position.normalized * (radius - baseBoid.transform.position.magnitude) * boundaryForce * Time.deltaTime;
        }
    }
}
