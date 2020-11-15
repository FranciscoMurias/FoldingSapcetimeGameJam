using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/SteeredCohesion")]
public class SteeredCohesionBehavior : FilteredFlockBehavior
{
    private Vector3 currentVelocity;
    public float agentSmoothTime = 0.5f;
    
    
    public override Vector3 CalculateMove(FlockAgent thisAgent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector3.zero;

        //add all points & average
        Vector3 cohesionMove = Vector3.zero;

        //check if we have a filter
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(thisAgent, context);

        foreach (Transform c in filteredContext)
        {
            cohesionMove += c.position;
        }

        cohesionMove /= context.Count;
        //cohesionMove.Normalize();

        //create offset from agent position
        cohesionMove -= thisAgent.transform.position;
        cohesionMove = Vector3.SmoothDamp(thisAgent.transform.forward, cohesionMove, ref currentVelocity, agentSmoothTime);

        return cohesionMove;
    }

}
