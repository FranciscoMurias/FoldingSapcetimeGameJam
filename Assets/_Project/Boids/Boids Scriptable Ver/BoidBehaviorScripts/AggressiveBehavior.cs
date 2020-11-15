using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Aggressive")]
public class AggressiveBehavior : FilteredFlockBehavior
{
    public float searchRadius;

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

        List<Transform> wideSearch = GetNearbyObjects(thisAgent);

        //do a second search in wider radius
        List<Transform> filteredWideSearch = (filter == null) ?  wideSearch: filter.Filter(thisAgent, wideSearch);

        foreach (Transform c in filteredWideSearch)
        {
            aggressiveMove += Vector3.Lerp(thisAgent.transform.position, c.transform.position, Time.time);
        }

        aggressiveMove.Normalize();

        //follows a target and fires
        thisAgent.CalculateShootingLogic();

        return aggressiveMove;
    }

    public List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, searchRadius);

        foreach (Collider c in contextColliders)
        {
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }

        return context;
    }
}
