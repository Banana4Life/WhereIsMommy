using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    private IntroState state;
    private Vector3 motherTarget;
    private float timeLeft;

    public float blendSpeed;
    public float speed;
    public GameObject momTalking;
    public GameObject blend;
    public GameObject later;

	// Use this for initialization
	void Start ()
	{
	    state = IntroState.MotherWalkingIn;
	    motherTarget = new Vector3(-22.23f, 0, -24.74f);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float distance;
	    switch (state)
	    {
	        case IntroState.MotherWalkingIn:
	            distance = Math.Abs(Vector3.Distance(gameObject.transform.position, motherTarget));
	            gameObject.transform.position += (motherTarget - gameObject.transform.position) * (speed / distance);

	            if (distance < speed)
	            {
	                timeLeft = 3f;
	                motherTarget = new Vector3(-26.24f, 0, -37.86f);
	                state = IntroState.MotherTalking;
	            }
	            break;
            case IntroState.MotherTalking:
                timeLeft -= Time.deltaTime;
                if (timeLeft > 0)
                {
                    momTalking.SetActive(true);
                }
                else
                {
                    momTalking.SetActive(false);
                    state = IntroState.MotherWalkingOut;
                }
                break;
            case IntroState.MotherWalkingOut:
                distance = Math.Abs(Vector3.Distance(gameObject.transform.position, motherTarget));
                gameObject.transform.position += (motherTarget - gameObject.transform.position) * (speed / distance);

                if (Math.Abs(Vector3.Distance(gameObject.transform.position, motherTarget)) < speed)
                {
                    state = IntroState.Blend;
                }
                break;
            case IntroState.Blend:
                later.SetActive(true);
                Color oldColor = blend.GetComponent<Image>().color;
                blend.GetComponent<Image>().color = new Color(oldColor.r, oldColor.g, oldColor.b, oldColor.a + blendSpeed);

                if (blend.GetComponent<Image>().color.a + blendSpeed > 1)
                {
                    SceneManager.LoadScene("Main");
                }
                break;
	    }
	}
}

public enum IntroState
{
    MotherWalkingIn,
    MotherTalking,
    MotherWalkingOut,
    Blend
}
