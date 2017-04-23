using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelCycler : MonoBehaviour
{
    public float modelDuration;
    public List<Mesh> meshes;
    private MeshFilter meshFilter;
    private int index;
    public bool startOnAttach = true;
    public float MinDelay = 1f;
    public float MaxDelay = 2f;
    public float Speed = 0f;
    private float delayUntilNext = 0f;

    private bool cycling = false;

	// Use this for initialization
	void Start () {
	    meshFilter = gameObject.GetComponent<MeshFilter>();
	    if (startOnAttach)
	    {
	        StartCycling();
	    }
	}

    private float calculateNextDelay()
    {
        return MinDelay + (MaxDelay - MinDelay) * (1f - Speed);
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (cycling)
	    {
	        if (delayUntilNext <= 0)
	        {
	            index = (index + 1) % meshes.Count;
	            meshFilter.mesh = meshes[index];
	            delayUntilNext = calculateNextDelay();
	        }
	        else
	        {
	            delayUntilNext -= Time.deltaTime;
	        }
	    }
	}

    void Animate()
    {
    }

    public bool IsCycling()
    {
        return cycling;
    }

    public void StartCycling(int startIndex = 0)
    {
        if (!IsCycling())
        {
            index = startIndex;
            delayUntilNext = calculateNextDelay();
            cycling = true;
        }
    }

    public void StopCycling()
    {
        cycling = false;
    }
}
