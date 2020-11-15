using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    private List<FlockAgent> agents = new List<FlockAgent>();

    public FlockBehavior behavior;

    [Range(10, 500)] public int startingCount = 250;
    private const float agentDensity = 0.08f;

    [Range(1f, 100f)] public float driveFactor = 10f;

    [Range(1f, 100f)] public float maxSpeed = 5f;

    [Range(1f, 10f)] public float neighborRadius = 1.5f;

    [Range(0f, 1f)] public float avoidanceRadiusMultiplier = 0.5f;

    private float sqrMaxSpeed;

    private float sqrNeighborRad;

    private float sqrAvoidanceRad;

    public EnemyManager enemyManagerRef;
    public float SqrAvoidanceRad { get { return sqrAvoidanceRad; } }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Flock start");

        sqrMaxSpeed = maxSpeed * maxSpeed;
        sqrNeighborRad = neighborRadius* neighborRadius;
        sqrAvoidanceRad = sqrNeighborRad * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitSphere * startingCount * agentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
            );

            newAgent.name = "Agent " + i;
            newAgent.managerRef = enemyManagerRef;
            newAgent.initialize(this);
            agents.Add(newAgent);
            
            enemyManagerRef.AddToEnemyList(newAgent.gameObject);
        }

        enemyManagerRef.ForceEnemyDisplayUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (FlockAgent agent in agents)
        {
            if (agent.gameObject.activeSelf == false)
                continue;

            List<Transform> context = GetNearbyObjects(agent);

            //FOR DEMO ONLY
            //agent.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.Lerp(Color.white, Color.red, context.Count/6f));

            Vector3 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > sqrMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }

            agent.Move(move);
        }
    }

    public List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighborRadius);

        foreach (Collider c in contextColliders)
        {
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }

        return context;
    }

    public List<FlockAgent> GetBoids()
    {
        return agents;
    }
}
