using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class ClickMyTile : MonoBehaviour
{
    public GameObject tehPlayer;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000, 1 << 9)) // Level 9 = Floor
            {
                var agent = tehPlayer.GetComponent<NavMeshAgent>();
                agent.SetDestination(hit.point);
            }
        }
    }
}