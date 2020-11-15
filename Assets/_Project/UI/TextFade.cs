using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextFade : MonoBehaviour
{
    public TextMeshProUGUI text;

    public float fadeTime = 3.0f;
    public float fadeCounter = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        fadeCounter += Time.deltaTime;

        if (fadeCounter >= fadeTime && text.color.a > 0)
        {
            Color newC = text.color;

            if (newC.a > 0)
            {
                newC.a -= Time.deltaTime;
                text.color = newC;
            }
                
        }
    }
}
