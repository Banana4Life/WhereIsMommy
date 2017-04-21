using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour
{
    public GameObject tile;
    public GameObject wall;

    public int height = 5;
    public int width = 5;

	// Use this for initialization
	void Start ()
	{
	    Debug.Log("Generating Terrain...");
	    var tileSize = tile.GetComponent<Renderer>().bounds.size;
	    var dx = tileSize.x;
	    var dy = tileSize.z;
	    for (int x = 0; x < height; x++)
	    {
	        for (int y = 0; y < width; y++)
	        {
	            var newTile = Instantiate(tile);
	            newTile.transform.position = new Vector3(x * dx, 0, y * dy);
	            newTile.transform.parent = gameObject.transform;
	            newTile.name = "Tile " + x + ":" + y;
	        }
	    }
	    // Initialize & Build NavMesh
	    var navMeshSurface = gameObject.AddComponent<NavMeshSurface>();
	    navMeshSurface.BuildNavMesh();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
