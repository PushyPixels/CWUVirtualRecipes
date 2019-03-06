﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBall : MonoBehaviour
{
    public float force = 10.0f;
    public ForceMode forceMode = ForceMode.Acceleration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,transform.localScale.x/2.0f);
        foreach(Collider col in colliders)
        {
            Rigidbody body = col.GetComponent<Rigidbody>();
            if(body)
            {
                body.AddExplosionForce(force,transform.position,transform.localScale.x/2.0f,0.0f,forceMode);
            }
        }
    }
}
