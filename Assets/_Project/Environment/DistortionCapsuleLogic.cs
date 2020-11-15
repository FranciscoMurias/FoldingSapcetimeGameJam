using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistortionCapsuleLogic : MonoBehaviour
{
    public float liveTime = 5f;
    private float lifeCounter = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeCounter += Time.deltaTime;

        if(lifeCounter >= liveTime)
            Destroy(gameObject);
    }
}
