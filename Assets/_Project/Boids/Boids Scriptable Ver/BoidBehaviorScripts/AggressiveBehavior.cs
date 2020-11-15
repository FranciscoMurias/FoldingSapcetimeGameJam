using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Aggressive")]
public class AggressiveBehavior : FilteredFlockBehavior
{
    public override Vector3 CalculateMove(FlockAgent thisAgent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
            return thisAgent.transform.forward;

        Vector3 aggressiveMove = Vector3.zero;

        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(thisAgent, context);

        foreach (Transform c in filteredContext)
        {
            aggressiveMove += c.transform.forward;
        }

        aggressiveMove.Normalize();

        //follows a target and fires
        thisAgent.CalculateShootingLogic();

        return aggressiveMove;
    }
}
