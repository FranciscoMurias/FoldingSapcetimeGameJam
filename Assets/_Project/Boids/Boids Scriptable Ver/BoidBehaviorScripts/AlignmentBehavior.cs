using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FilteredFlockBehavior
{
    public override Vector3 CalculateMove(FlockAgent thisAgent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return no adjustment
        if (context.Count == 0)
            return thisAgent.transform.forward;

        //add all points & average
        Vector3 alignmentMove = Vector3.zero;

        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(thisAgent, context);

        foreach (Transform c in filteredContext)
        {
            alignmentMove += c.transform.forward;
        }

        alignmentMove /= context.Count;
        //alignmentMove.Normalize();

        return alignmentMove;
    }

}
