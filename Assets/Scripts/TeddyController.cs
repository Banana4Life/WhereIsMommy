using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyController : MonoBehaviour
{
    public GameObject player;

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
            playerController.carryTeddy = true;
            // TODO show StoryText
        }
    }
}
