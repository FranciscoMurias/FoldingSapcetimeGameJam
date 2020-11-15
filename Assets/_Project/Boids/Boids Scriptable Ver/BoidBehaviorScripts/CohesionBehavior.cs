using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class CohesionBehavior : FilteredFlockBehavior
{
    public override Vector3 CalculateMove(FlockAgent thisAgent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector3.zero;

        //add all points & average
        Vector3 cohesionMove = Vector3.zero;


        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(thisAgent, context);

        foreach (Transform c in filteredContext)
        {
            cohesionMove += c.position;
        }

        cohesionMove.Normalize();

        //create offset from agent position
        cohesionMove -= thisAgent.transform.position;

        return cohesionMove;
    }

}
