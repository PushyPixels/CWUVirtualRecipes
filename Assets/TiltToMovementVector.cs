using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltToMovementVector : MonoBehaviour
{
    public float xTilt;
    public float zTilt;
	
	// Update is called once per frame
	void Update ()
    {
	    // Get X tilt and convert to float
        Vector3 rightVector = Vector3.ProjectOnPlane(transform.right,Vector3.up).normalized;
        xTilt = 1.0f - Vector3.Dot(rightVector,transform.right);
        xTilt *= Mathf.Sign(transform.right.y);

        // Get Z tilt and convert to float
        Vector3 forwardVector = Vector3.ProjectOnPlane(transform.forward,Vector3.up).normalized;
        zTilt = 1.0f - Vector3.Dot(forwardVector,transform.forward);
        zTilt *= Mathf.Sign(transform.forward.y);
	}
}
