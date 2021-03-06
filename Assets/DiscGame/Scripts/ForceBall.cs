﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBall : MonoBehaviour
{
    public Editable forceEditable;
    public ForceMode forceMode = ForceMode.Acceleration;
    public bool applyDrag = false;
    public float dragAmount = 1.0f;

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
            if(body && body != GetComponent<Rigidbody>())
            {
                body.AddExplosionForce(forceEditable.value,transform.position,transform.localScale.x/2.0f,0.0f,forceMode);
                if(applyDrag)
                {
                    body.drag += dragAmount;
                }
            }
        }
    }
}
