using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior : FilteredFlockBehavior
{
    public override Vector3 CalculateMove(FlockAgent thisAgent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector3.zero;

        //add all points & average
        Vector3 avoidanceMove = Vector3.zero;
        int agentsInAvoid = 0;

        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(thisAgent, context);

        foreach (Transform c in filteredContext)
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
