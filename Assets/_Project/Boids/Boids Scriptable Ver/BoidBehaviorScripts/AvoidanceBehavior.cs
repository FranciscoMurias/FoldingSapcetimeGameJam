using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior : FlockBehavior
{
    public override Vector3 CalculateMove(FlockAgent thisAgent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector3.zero;

        //add all points & average
        Vector3 avoidanceMove = Vector3.zero;
        int agentsInAvoid = 0;

        foreach (Transform c in context)
        {
            if (Vector3.SqrMagnitude(c.position - thisAgent.transform.position) < flock.SqrAvoidanceRad)
            {
                agentsInAvoid++;
                avoidanceMove += thisAgent.transform.position - c.position;
            }

        }

        if (agentsInAvoid > 0)
        {
            avoidanceMove.Normalize();
        }

        return avoidanceMove;
    }

}
