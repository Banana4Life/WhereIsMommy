using System;
using System.Collections.Generic;
using UnityEngine;

public class TextHider : MonoBehaviour
{
    private Dictionary<GameObject, float> texts;

	void Start ()
	{
	    texts = new Dictionary<GameObject, float>();
	}

	void Update ()
	{
	    foreach (var key in new List<GameObject>(texts.Keys))
	    {
	        texts[key] -= Time.deltaTime;
	        if (texts[key] < 0)
	        {
	            texts.Remove(key);
	            key.SetActive(false);
	        }
	    }
	}

    public void HideTextIn(GameObject text, float time)
    {
        texts[text] = time;
    }
}
