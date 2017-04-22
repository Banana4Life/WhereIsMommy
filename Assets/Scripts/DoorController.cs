using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public String RequiredKey;
    public Vector3 RelativeRotationAxis = Vector3.zero;
    public bool ClockWise = true;
    private bool isOpen = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponentInParent<KeyHolder>().MayOpen(RequiredKey))
        {
            ChangeState(true);
        }
    }

    public void ChangeState(bool open)
    {
        if (open != isOpen)
        {
            isOpen = open;
            gameObject.transform.RotateAround(gameObject.transform.position + RelativeRotationAxis, Vector3.up,
                90 * (ClockWise && open ? 1 : -1));
        }
    }
}