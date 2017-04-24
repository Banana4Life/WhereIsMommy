using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoorController : CollisionController {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void handle(PlayerController pc)
    {
        if (pc.buttonsPressed == 3)
        {
            Debug.Log("Trigger Ending...");
            // TODO trigger end scene
        }
    }
}
