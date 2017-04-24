using UnityEngine;

public class IntroController : MonoBehaviour
{

    public GameObject title;

    private float timeLeft;

	void Start ()
	{
	    timeLeft = 3f;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timeLeft -= Time.deltaTime;
	    if (timeLeft < 0)
	    {
	        title.SetActive(false);
	        gameObject.SetActive(false);
	    }
	}
}
