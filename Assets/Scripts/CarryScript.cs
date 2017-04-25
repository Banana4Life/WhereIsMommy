using UnityEngine;

public class CarryScript : MonoBehaviour {

    [Header("CarriedStuff")]
    public GameObject teddy;
    public GameObject flashlight;
    public GameObject uvLight;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;

    [Header("State")]
    public bool carryTeddy;
    public bool carryLight;
    public bool carryUvLight;
    public bool carryKey1;
    public bool carryKey2;
    public bool carryKey3;
    public int carryMatches = 0;

	// Use this for initialization
	void Start ()
	{
	    carryTeddy = false;
	    carryLight = false;
	    carryUvLight = false;
	    carryKey1 = false;
	    carryKey2 = false;
	    carryKey3 = false;
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
        uvLight.SetActive(carryUvLight);
        key1.SetActive(carryKey1);
        key2.SetActive(carryKey2);
        key3.SetActive(carryKey3);
    }
}
