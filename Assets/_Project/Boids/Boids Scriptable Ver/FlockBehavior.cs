using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehavior : ScriptableObject
{
    //thisAgent - agent we're working with
    //context - neighbors around 
    //flock - flock itself
    public abstract Vector3 CalculateMove(FlockAgent thisAgent, List<Transform> context, Flock flock);
}
