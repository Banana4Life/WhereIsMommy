using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public GameObject textObject;

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
        Invoke("HideText", time);
    }

    private void HideText()
    {
        textObject.SetActive(false);
    }

    public static TextController Get()
    {
        return GameObject.Find("TextController").GetComponent<TextController>();
    }
}
