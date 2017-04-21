using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var newPos = gameObject.transform.position;
	    newPos.y += 20;
	    cam.transform.position = newPos;
	}
}
