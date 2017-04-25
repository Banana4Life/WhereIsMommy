using UnityEngine;

public class TurnOffFullLight : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    gameObject.GetComponent<Light>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
