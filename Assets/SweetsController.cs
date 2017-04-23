using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetsController : CollisionController
{

    private PlayerController pc;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void handle(PlayerController playerController)
    {
        playerController.ForceMovement(gameObject.transform.position);
        pc = playerController;
        TextController.Get().ShowText("Mhhm. Sweets!", Color.red, 5f);
        Invoke("StopEating", 5f);
    }

    private void StopEating()
    {
        pc.StopForceMovement();
        gameObject.SetActive(false);
    }
}
