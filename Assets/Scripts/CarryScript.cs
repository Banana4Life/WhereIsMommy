using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryScript : MonoBehaviour {

    [Header("CarriedStuff")]
    public GameObject teddy;
    public GameObject flashlight;
    public GameObject key1;
    public GameObject key2;

    [Header("State")]
    public bool carryTeddy;
    public bool carryLight;
    public bool carryKey1;
    public bool carryKey2;
    public int carryMatches = 0;

	// Use this for initialization
	void Start ()
	{
	    carryTeddy = false;
	    carryLight = false;
	    carryKey1 = false;
	    carryKey2 = false;
	    carryMatches = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    UpdateCarry();
	}

    private void UpdateCarry()
    {
        teddy.SetActive(carryTeddy);
        flashlight.SetActive(carryLight);
        key1.SetActive(carryKey1);
        key2.SetActive(carryKey2);
    }
}
