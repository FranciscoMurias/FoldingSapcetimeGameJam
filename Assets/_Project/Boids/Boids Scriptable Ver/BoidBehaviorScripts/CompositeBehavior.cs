using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehavior : FlockBehavior
{
    public FlockBehavior[] behaviors;
    public float[] weights;

    public override Vector3 CalculateMove(FlockAgent thisAgent, List<Transform> context, Flock flock)
    {
        //handle data mismatch
        if (behaviors.Length != weights.Length)
        {
            Debug.LogError("Data mismatch in " + name, this);
            return Vector3.zero;
        }
            
        //setup move

        Vector3 move = Vector3.zero;

        //iterate through behaviors
        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector3 partialMove = behaviors[i].CalculateMove(thisAgent, context, flock) * weights[i];

            if (partialMove != Vector3.zero)
            {
                //does overall move exceed weight
                if (partialMove.sqrMagnitude < weights[i] * weights[i])
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }

                move += partialMove;
            }
        }

        return move;
    }
}
