using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodyTrailController : CollisionController {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void handle(PlayerController pc)
    {
        pc.bloodyTrail = true;
    }
}
