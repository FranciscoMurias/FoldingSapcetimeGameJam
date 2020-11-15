using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/MoveTowards")]
public class MoveTowardsBehavior : FilteredFlockBehavior
{
    public float targetSearchRadius = 75f;

    public override Vector3 CalculateMove(FlockAgent thisAgent, List<Transform> context, Flock flock)
    {
        //look at context as well as farther distances

        List<Transform> targetContext = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(thisAgent.transform.position, targetSearchRadius);

        foreach (Collider c in contextColliders)
        {
            if (c != thisAgent.AgentCollider)
            {
                targetContext.Add(c.transform);
            }
        }

        //if no neighbors, return no adjustment
        if (context.Count == 0 || targetContext.Count == 0)
            return thisAgent.transform.forward;

        //add all points & average
        Vector3 moveTowardsMove = Vector3.zero;

        //move towards objects in filters

        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(thisAgent, context);

        foreach (Transform c in filteredContext)
        {
            moveTowardsMove += c.position;
        }

        moveTowardsMove.Normalize();
        //alignmentMove.Normalize();

        return moveTowardsMove;
    }
}
