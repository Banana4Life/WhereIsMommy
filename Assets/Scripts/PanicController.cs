﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(NavMeshAgent))]
public class PanicController : MonoBehaviour
{
    public float PanicLevel;
    public float PanicThreshold = 300;
    public float PanicIncrease = 10;
    public float PanicIncreaseNoFlash = 30;
    public float PanicDecrease = 10;
    public GameObject ReturnTo;

    // Update is called once per frame
    void Update()
    {
        var candles = GameObject.FindGameObjectsWithTag("Candle");
        var inDarkness = !candles.Any(IsInLight);
        var hasFlashLight = GetComponent<PlayerController>().carryLight;

        float increase;
        if (inDarkness)
        {
            increase = hasFlashLight ? PanicIncrease : PanicIncreaseNoFlash;
        }
        else
        {
            increase = -PanicDecrease;
        }
        PanicLevel = Math.Max(PanicLevel + increase * Time.deltaTime, 0f);

        var playerCtrl = GetComponent<PlayerController>();
        if (!playerCtrl.Panic)
        {
            if (PanicLevel > PanicThreshold)
            {
                var navAgent = GetComponent<NavMeshAgent>();
                navAgent.enabled = true;
                playerCtrl.Panic = true;
                navAgent.SetDestination(ReturnTo.transform.position);
            }
        }
        else
        {
            var navAgent = GetComponent<NavMeshAgent>();
            if (DidAgentReachDestination(navAgent))
            {
                Debug.LogWarning("Destination Fucked!");
                playerCtrl.Panic = false;
                navAgent.enabled = false;
                PanicLevel = 0;
            }
        }
    }

    private static bool DidAgentReachDestination(NavMeshAgent agent)
    {
        return Vector3.Distance(agent.gameObject.transform.position, agent.destination) < 0.1f;
    }

    private bool IsInLight(GameObject candle)
    {
        var range = candle.GetComponentInChildren<Light>().range;
        var direction = transform.position - candle.transform.position;
        var distance = Vector3.Magnitude(direction);
        if (distance <= range)
        {
            RaycastHit hit;
            Physics.Raycast(candle.transform.position, direction, out hit, distance);
            return hit.collider.GetComponentInParent<PlayerController>();
        }
        return false;
    }
}