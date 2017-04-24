using System;
using JetBrains.Annotations;
using UnityEngine;using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class IntroScript : MonoBehaviour
{
    private IntroState state;
    private Vector3 motherTarget;
    private float timeLeft;

    public float blendSpeed;
    public float speed;
    public GameObject blend;
    public GameObject later;

    private NavMeshAgent navAgent;
    public GameObject Destination;
    private Vector3 origin;

	// Use this for initialization
	void Start ()
	{
	    state = IntroState.MotherWalkingIn;
	    motherTarget = new Vector3(-22.23f, 0, -24.74f);
	    navAgent = GetComponent<NavMeshAgent>();
	    origin = Vector3.zero + transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    switch (state)
	    {
	        case IntroState.MotherWalkingIn:
	            if (!navAgent.enabled)
	            {
	                navAgent.enabled = true;
	                navAgent.SetDestination(Destination.transform.position);
	            }
	            else if (navAgent.remainingDistance < navAgent.stoppingDistance)
	            {
	                navAgent.enabled = false;
	                timeLeft = 3f;
	                state = IntroState.MotherTalking;
	            }
	            break;
            case IntroState.MotherTalking:
                TextController.Get().ShowText("Do not leave the room. We are back soon.", new Color(150/255f, 193/255f, 72/255f), 3f);
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0)
                {
                    state = IntroState.MotherWalkingOut;
                }
                break;
            case IntroState.MotherWalkingOut:
                if (!navAgent.enabled)
                {
                    navAgent.enabled = true;
                    navAgent.SetDestination(origin);
                }
                else if (navAgent.remainingDistance < navAgent.stoppingDistance)
                {
                    navAgent.enabled = false;
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
