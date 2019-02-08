using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleThing : MonoBehaviour
{
    public Transform ball;
    public Vector3 speed = Vector3.one;

    private float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = ball.localPosition;
        newPosition.x = Mathf.Sin(2f * Mathf.PI * t * speed.x);
        newPosition.y = Mathf.Cos(2f * Mathf.PI * t * speed.y);
        newPosition.z = Mathf.Sin(2f * Mathf.PI * t * speed.z);
        ball.localPosition = newPosition;
        t += Time.deltaTime;
    }
}
