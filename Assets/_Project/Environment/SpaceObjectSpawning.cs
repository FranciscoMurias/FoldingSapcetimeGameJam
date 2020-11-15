using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObjectSpawning : MonoBehaviour
{
    public GameObject warpSpaceObj;

    public float spawnTime = 4.0f;
    public float spawnCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter += Time.deltaTime;

        if (spawnCounter >= spawnTime)
        {
            //spawn space obj w/ random rotation somewhere on edge of obj
            
            //spawn from a random point on mesh
            Vector3[] v = GetComponent<MeshFilter>().mesh.vertices;
            int vertIndex = Random.Range(0, v.Length);

            Vector3 randPoint = transform.TransformPoint(v[vertIndex]);

            Quaternion rot = Quaternion.Euler(0,0,120f);

            Instantiate(warpSpaceObj, randPoint, rot);

            spawnCounter = 0.0f;
        }
    }
}
