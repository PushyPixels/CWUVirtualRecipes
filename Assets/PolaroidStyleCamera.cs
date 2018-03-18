using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolaroidStyleCamera : MonoBehaviour
{
    public RenderTexture rt;
    public Renderer picturePrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakePicture()
    {
        Debug.Log("Taking picture");
    }
}
