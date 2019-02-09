using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleThing : MonoBehaviour
{
    public Transform ball;
    public Vector3 speed = Vector3.one;
    public float scale = 1.0f;
    public bool randomize = false;

    private float t;

    // Start is called before the first frame update
    void Start()
    {
        if(randomize)
        {
            speed = Random.insideUnitSphere;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = ball.localPosition;
        newPosition.x = Mathf.Sin(2f * Mathf.PI * t * speed.x * scale);
        newPosition.y = Mathf.Cos(2f * Mathf.PI * t * speed.y * scale);
        newPosition.z = Mathf.Sin(2f * Mathf.PI * t * speed.z * scale);
        ball.localPosition = newPosition;
        t += Time.deltaTime;
    }
}
