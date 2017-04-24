using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCameraController : MonoBehaviour
{

    public GameObject camera;
    public GameObject girl;

    private Vector3 targetPosition = new Vector3(0, 70, -80);
    private Vector3 velocityMovement = Vector3.zero;
    private float velocityRotationX;
    private float velocityRotationZ;
    private float timeLeft = 0.7f;

    private Vector3 girlTargetPosition = new Vector3(-0.21f, 39.7f, -30.987f);
    private float girlWalkingOutTime = 1.3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (girlWalkingOutTime > 0)
	    {
	        girlWalkingOutTime -= Time.deltaTime;

	        girl.transform.position = Vector3.Lerp(girl.transform.position, girlTargetPosition, Time.deltaTime / girlWalkingOutTime);
	    }
	    else
	    {
	        timeLeft -= Time.deltaTime;
	        if (timeLeft < 0)
	        {
	            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocityMovement, 2f);
	            camera.transform.rotation = Quaternion.Euler(
	                new Vector3(Mathf.SmoothDampAngle(camera.transform.eulerAngles.x, 25f, ref velocityRotationX, 1f), 0, Mathf.SmoothDampAngle(camera.transform.eulerAngles.z, 45f, ref velocityRotationZ, 2f)));
	        }
	    }
	}
}
