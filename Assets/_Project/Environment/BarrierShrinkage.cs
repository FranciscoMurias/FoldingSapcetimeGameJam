using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierShrinkage : MonoBehaviour
{
    private float shrinkRate = 0.0f;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newX = transform.localScale.x - shrinkRate;
        float newY = transform.localScale.y - shrinkRate;
        float newZ = transform.localScale.z - shrinkRate;

        Vector3 newScale = new Vector3(newX, newY, newZ);

        transform.localScale = newScale;
    }

    //increase shrink rate at various times
    public void ApplyShrinkRate(float sr)
    {
        shrinkRate = sr;
    }

    //enemies and player can gain extra hits by defeating each other
}
