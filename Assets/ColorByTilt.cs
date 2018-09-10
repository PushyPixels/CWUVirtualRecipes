using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorByTilt : MonoBehaviour
{
    public enum Mode {xPositive,xNegative,zPositive,zNegative};

    public TiltToMovementVector tilt;
    public Gradient gradient;
    public Mode mode;
    public new Renderer renderer;

    private void OnValidate()
    {
        if(!renderer)
        {
            renderer = GetComponent<Renderer>();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if(mode == Mode.xPositive || mode == Mode.xNegative)
        {
            float value = tilt.xTilt;
            if(mode == Mode.xNegative)
            {
                value = -value;
            }
            renderer.material.color = gradient.Evaluate(value);
        }
        else if(mode == Mode.zPositive || mode == Mode.zNegative)
        {
            float value = tilt.zTilt;
            if(mode == Mode.zNegative)
            {
                value = -value;
            }
            renderer.material.color = gradient.Evaluate(value);
        }
	}
}
