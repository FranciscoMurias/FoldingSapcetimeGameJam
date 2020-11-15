using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierShrinkage : MonoBehaviour
{
    [Range(0f, 5f)]
    public float startingShrinkRate = 0.0f;

    private float currentShrinkRate = 0.0f;

    public GameObject outsideSphere;

    //jutting space capsule spawning managed here? - should also destroy asteroids

    // Start is called before the first frame update
    void Start()
    {
        currentShrinkRate = startingShrinkRate;
    }

    // Update is called once per frame
    void Update()
    {
        float newX = transform.localScale.x - currentShrinkRate;
        float newY = transform.localScale.y - currentShrinkRate;
        float newZ = transform.localScale.z - currentShrinkRate;

        float newOutX = outsideSphere.transform.localScale.x - currentShrinkRate/1000f;
        float newOutY = outsideSphere.transform.localScale.y - currentShrinkRate/1000f;
        float newOutZ = outsideSphere.transform.localScale.z - currentShrinkRate/1000f;

        Vector3 newScale = new Vector3(newX, newY, newZ);
        Vector3 newOutScale = new Vector3(newOutX, newOutY, newOutZ);

        transform.localScale = newScale;
        outsideSphere.transform.localScale = newOutScale;
    }

    //increase shrink rate at various times
    public void ApplyShrinkRate(float sr)
    {
        Debug.Log("Trying to apply shrink data of " + sr);
        currentShrinkRate = sr;
    }

    //enemies and player can gain extra hits by defeating each other
}
