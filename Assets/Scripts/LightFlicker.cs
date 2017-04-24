using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    private Light light;
    private float timeLeft;

	// Use this for initialization
	void Start ()
	{
	    light = gameObject.GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timeLeft -= Time.deltaTime;
	    if (timeLeft < 0) {
	        light.intensity = 3f + 1.5f * Random.value;
	        timeLeft = 0.15f;
	    }
	}
}
