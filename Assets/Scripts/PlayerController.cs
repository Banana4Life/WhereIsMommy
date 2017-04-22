using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public int speed = 4;

    public Camera cam;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000, 1 << 9)) // Level 9 = Floor
            {
                var agent = gameObject.GetComponent<NavMeshAgent>();
                agent.SetDestination(hit.point);
            }
        }
        */

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(x * speed, 0, y * speed);

        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, 1 << 9)) // Level 9 = Floor
        {
            var hitPoint = hit.point;
            hitPoint.y = gameObject.transform.position.y;
            gameObject.transform.LookAt(hitPoint);
        }

    }
}