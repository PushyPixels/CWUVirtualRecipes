using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBall : MonoBehaviour
{
    public float force = 10.0f;
    public ForceMode forceMode = ForceMode.Acceleration;
    public float radius = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius);
        foreach(Collider col in colliders)
        {
            Rigidbody body = col.GetComponent<Rigidbody>();
            if(body)
            {
                body.AddExplosionForce(force,transform.position,radius,0.0f,forceMode);
            }
        }
    }
}
