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
        TextController.Get().ShowText("It reads: C B A", Color.red, 10f);
    }
}
