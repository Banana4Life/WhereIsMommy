using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public GameObject textObject;
    public float time;

	void Start ()
	{
	}

	void Update ()
	{
	    if (time > 0)
	    {
	        time -= Time.deltaTime;
	        if (time < 0)
	        {
	            textObject.SetActive(false);
	        }
	    }
	}

    public void ShowText(string text, Color color, float hideIn = 0f)
    {
        var theText = textObject.GetComponent<Text>();
        theText.text = text;
        theText.color = color;
        textObject.SetActive(true);
        if (hideIn > 0)
        {
            HideTextIn(hideIn);
        }
    }

    public void HideTextIn(float time)
    {
        this.time = time;
    }
}
