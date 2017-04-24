using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public GameObject worldModel;
    public float tilt = 0;
    public float tiltSpeed = 35;

    public Vector3 camOffset = new Vector3(0, 15, -5);
    public Vector3 untiltedOffset;

	// Use this for initialization
	void Start ()
	{
	    untiltedOffset = camOffset;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var newPos = gameObject.transform.position;
	    newPos += camOffset;
	    cam.transform.position = newPos;

	    RaycastHit hit;
	    var playerPos = transform.position;
	    var cameraPos = playerPos + untiltedOffset;
	    var raycast = Physics.Raycast(cameraPos, playerPos - cameraPos, out hit);
	    if (raycast)
	    {
	        var hitWorld = hit.collider.gameObject == worldModel;
	        Vector3 rotAxis = Vector3.Cross(camOffset, Vector3.up);
	        if (hitWorld && tilt < 15)
	        {
	            var newTilt = Math.Min(15, tilt + Time.deltaTime * tiltSpeed);
                cam.transform.RotateAround(playerPos, rotAxis, Time.deltaTime * tiltSpeed);
	            camOffset = cam.transform.position - transform.position;
	            tilt = newTilt;
	        }
	        else if (!hitWorld && tilt > 0)
	        {
	            var newTilt = Math.Max(0, tilt - Time.deltaTime * tiltSpeed);
	            cam.transform.RotateAround(playerPos, rotAxis, -Time.deltaTime * tiltSpeed);
	            camOffset = cam.transform.position - transform.position;
	            tilt = newTilt;
	        }
	    }

	}

    private void OnDrawGizmos()
    {
        Vector3 rotAxis = Vector3.Cross(cam.transform.position - gameObject.transform.position, Vector3.up);
        Gizmos.DrawRay(transform.position, rotAxis);
    }
}
