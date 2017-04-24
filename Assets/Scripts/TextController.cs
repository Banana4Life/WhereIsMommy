using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public GameObject textObject;

    public static Color red = new Color(197/255f, 46/255f ,36/255f);

    public void ShowText(string text, Color color, float hideIn = 0f)
    {
        var theText = textObject.GetComponent<Text>();
        theText.text = text;
        theText.color = color;
        textObject.SetActive(true);
        if (hideIn > 0)
        {
            CancelInvoke("HideTextIn");
            HideTextIn(hideIn);
        }
    }

    public void HideTextIn(float time)
    {
        if (!IsInvoking("HideText"))
        {
            Invoke("HideText", time);
        }
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
