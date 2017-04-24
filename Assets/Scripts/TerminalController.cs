using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalController : CollisionController {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void handle(PlayerController pc)
    {
        TextController.Get().ShowText("It reads: " + pc.combination[0] + " "
                                                   + pc.combination[1] + " "
                                                   + pc.combination[2], TextController.red, 10f);
    }
}
