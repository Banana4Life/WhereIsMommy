using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;

    public Vector3 camOffset = new Vector3(0, 15, -5);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var newPos = gameObject.transform.position;
	    newPos += camOffset;
	    cam.transform.position = newPos;
	}
}
