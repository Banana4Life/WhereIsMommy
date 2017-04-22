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

	// Use this for initialization
	void Start () {
	    meshFilter = gameObject.GetComponent<MeshFilter>();
	    if (startOnAttach)
	    {
	        StartCycling();
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Animate()
    {
        meshFilter.mesh = meshes[index];
        index = (index + 1) % meshes.Count;
    }

    public bool IsCycling()
    {
        return IsInvoking("Animate");
    }

    public void StartCycling(int startIndex = 0)
    {
        if (!IsCycling())
        {
            index = startIndex;
            InvokeRepeating("Animate", 0, modelDuration);
        }
    }

    public void StopCyclign()
    {
        CancelInvoke("Animate");
    }
}
