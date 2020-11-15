using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Stay In Radius")]
public class StayInRadiusBehavior : FlockBehavior
{
    public Vector3 center;
    public float radius = 15f;

    // Start is called before the first frame update
    public override Vector3 CalculateMove(FlockAgent thisAgent, List<Transform> context, Flock flock)
    {
        Vector3 centeroffset = center - thisAgent.transform.position;
        float t = centeroffset.magnitude / radius;

        if (t < 0.9f)
        {
            return Vector3.zero;
        }

        return centeroffset * t * t;
    }
}
