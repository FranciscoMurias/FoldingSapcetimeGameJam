using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveBehavior : FlockBehavior
{
    public override Vector3 CalculateMove(FlockAgent thisAgent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
            return thisAgent.transform.forward;

        Vector3 aggressiveMove = Vector3.zero;

        //follows a target

        return aggressiveMove;
    }
}
