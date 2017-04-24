﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{

    public GameObject girl;

    private PlayerController playerController;
    private float timeLeft;

	void Start ()
	{
	    playerController = girl.GetComponent<PlayerController>();
	    timeLeft = 0.5f;
	    TextController.Get().ShowText("Where is Mommy?", TextController.red, 2f);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    playerController.forceMovement = true;
	    timeLeft -= Time.deltaTime;
	    if (timeLeft < 0)
	    {
	        playerController.forceMovement = false;
	        gameObject.SetActive(false);
	    }
	}
}
