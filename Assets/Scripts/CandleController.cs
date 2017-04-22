using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : CollisionController
{
    public bool lit;

    void Start()
    {
        UpdateLight();
    }

    void UpdateLight()
    {
        var lights = gameObject.GetComponentsInChildren<Light>();
        foreach (var light in lights)
        {
            light.enabled = lit;
        }
    }


    protected override void handle(PlayerController playerController)
    {
        if (playerController.carryMatches)
        {
            lit = true;
            UpdateLight();
            // TODO Text
        }
        else
        {
            // TODO # I need something to light this candle #
        }
    }
}
