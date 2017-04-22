using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;

    public int camHeight = 10;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var newPos = gameObject.transform.position;
	    newPos.y += camHeight;
	    cam.transform.position = newPos;
	}
}
