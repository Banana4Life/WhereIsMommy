using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;

    [Header("Settings")]
    public float Thrust = 2000;
    public float Epsilon = 0.1f;

    [Header("State")]
    public bool carryTeddy = false;

    public int panic = 0;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RotateToMouse();
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        var rb = GetComponent<Rigidbody>();
        if (Math.Abs(x) > Epsilon || Math.Abs(y) > Epsilon)
        {
            rb.AddForce(new Vector3(x, 0, y).normalized * Thrust * Time.deltaTime);
        }
        else
        {
            var change = new Vector3(rb.velocity.x / -2, 0, rb.velocity.z / -2);
            rb.AddForce(change, ForceMode.VelocityChange);
        }


        // else Girl runs in panic to the bed
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



    }

    private void RotateToMouse()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, 1 << 9)) // Level 9 = Floor
        {
            var hitPoint = hit.point;
            hitPoint.y = gameObject.transform.position.y;
            gameObject.transform.LookAt(hitPoint);
        }
    }

    void FixedUpdate()
    {
//        if (panic < 100)
//        {
//            var x = Input.GetAxis("Horizontal");
//            var y = Input.GetAxis("Vertical");
//
//            if (Math.Abs(x) < 0.2)
//            {
//                x = 0;
//            }
//            if (Math.Abs(y) < 0.2)
//            {
//                y = 0;
//            }
////            Debug.Log(x + ":" + y);
//
////            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(x * speed, 0, y * speed);
//            var targetPos = gameObject.transform.position + new Vector3(x, 0, y).normalized * speed;
//            //gameObject.GetComponent<Rigidbody>().MovePosition(targetPos);
//
//            var agent = gameObject.GetComponent<NavMeshAgent>();
//            if (x == 0 && y == 0)
//            {
//                agent.isStopped = true;
//            }
//            else
//            {
//                agent.isStopped = false;
//                agent.SetDestination(targetPos);
//            }
//
//        }
    }

}