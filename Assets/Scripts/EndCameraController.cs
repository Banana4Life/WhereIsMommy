using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCameraController : MonoBehaviour
{

    public GameObject camera;

    private Vector3 targetPosition = new Vector3(0, 70, -80);
    private Vector3 velocityMovement = Vector3.zero;
    private float velocityRotation;
    private float timeLeft = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timeLeft -= Time.deltaTime;
	    if (timeLeft < 0)
	    {
	        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocityMovement, 2f);
	        camera.transform.rotation = Quaternion.Euler(
	            new Vector3(Mathf.SmoothDampAngle(camera.transform.eulerAngles.x, 25f, ref velocityRotation, 1f), 0, 0));
	    }
	}
}
