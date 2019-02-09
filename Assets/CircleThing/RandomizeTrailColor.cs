using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeTrailColor : MonoBehaviour
{
    public TrailRenderer tRenderer;

    private void OnValidate()
    {
        if(tRenderer == null)
        {
            tRenderer = GetComponent<TrailRenderer>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GradientColorKey[] colorKey = new GradientColorKey[2];
        colorKey[0].color = Random.ColorHSV(0.0f,1.0f);
        colorKey[0].time = 0.0f;
        colorKey[1].color = colorKey[0].color;
        colorKey[1].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        GradientAlphaKey[] alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;
        tRenderer.colorGradient.colorKeys = colorKey;
        tRenderer.colorGradient.alphaKeys = alphaKey;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
