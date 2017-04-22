using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyController : MonoBehaviour
{
    public GameObject player;
    public GameObject teddyText;
    public GameObject textHider;

    private float teddyTextTimeLeft = 0;

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
            textHider.GetComponent<TextHider>().HideTextIn(teddyText, 4f);
            teddyText.SetActive(true);
        }
    }
}
