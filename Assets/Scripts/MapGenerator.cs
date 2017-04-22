using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
	    // Build Navmesh for all tiles under gameObject
	    var navMeshSurface = gameObject.AddComponent<NavMeshSurface>();
	    navMeshSurface.BuildNavMesh();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
