using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public GameObject worldModel;
    private bool tilted = false;

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
	        Debug.Log(hit.collider.name);
	        Vector3 rotAxis = Vector3.Cross(camOffset, Vector3.up);
	        if (hitWorld && !tilted)
	        {
	            untiltedOffset = camOffset;
	            cam.transform.RotateAround(playerPos, rotAxis, 15);
	            camOffset = cam.transform.position - transform.position;
	            tilted = true;
	        }
	        else if (!hitWorld && tilted)
	        {
	            cam.transform.RotateAround(playerPos, rotAxis, -15);
	            camOffset = untiltedOffset;
	            tilted = false;
	        }
	    }
	}

    private void OnDrawGizmos()
    {
        Vector3 rotAxis = Vector3.Cross(cam.transform.position - gameObject.transform.position, Vector3.up);
        Gizmos.DrawRay(transform.position, rotAxis);
    }
}
