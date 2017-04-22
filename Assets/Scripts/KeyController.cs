using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{

    public String keyName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision other)
    {
        var playerController = other.gameObject.GetComponentInParent<PlayerController>();

        if (playerController != null)
        {
            gameObject.SetActive(false);
            var keyHolder = playerController.gameObject.GetComponent<SpecificKeyHolder>();
            keyHolder.key.Add(keyName);
            // TODO show StoryText
        }
    }
}
