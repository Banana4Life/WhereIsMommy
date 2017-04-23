using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public String RequiredKey;
    public Vector3 RelativeRotationAxis = Vector3.zero;
    public bool ClockWise = true;
    public float RotationSpeed = 45f;
    private bool isOpen = false;
    private bool changing = false;
    private Quaternion targetRotation;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (changing)
        {
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
            if (targetRotation == gameObject.transform.rotation)
            {
                changing = false;
            }
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        var keyHolder = other.gameObject.GetComponentInParent<KeyHolder>();
        if (keyHolder.MayOpen(RequiredKey))
        {
            if (!isOpen && RequiredKey.Length != 0)
            {
                TextController.Get().ShowText("The key works!", Color.red, 4f);
            }
            ChangeState(true);
        }
        else
        {
            TextController.Get().ShowText("It's locked!", Color.red, 4f);
        }
    }

    public void ChangeState(bool open)
    {
        if (open != isOpen)
        {
            isOpen = open;
            changing = true;
            var direction = 90 * (ClockWise && open ? 1 : -1);
            targetRotation = gameObject.transform.rotation * Quaternion.Euler(Vector3.up * direction);
        }
    }
}