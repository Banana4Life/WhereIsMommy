using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BigDoorController : CollisionController
{

    public GameObject blend;

    private float blendSpeed = 0.1f;
    private bool triggered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (triggered)
	    {
	        Color oldColor = blend.GetComponent<Image>().color;
	        blend.GetComponent<Image>().color = new Color(oldColor.r, oldColor.g, oldColor.b, oldColor.a + blendSpeed);

	        if (blend.GetComponent<Image>().color.a + blendSpeed > 1)
	        {
	            SceneManager.LoadScene("End");
	        }
	    }
	}

    protected override void handle(PlayerController pc)
    {
        if (pc.buttonsPressed == 3)
        {
            triggered = true;
        }
    }
}
