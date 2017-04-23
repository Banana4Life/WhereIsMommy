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
        if (!lit)
        {
            if (playerController.Carry().carryMatches > 0)
            {
                playerController.Carry().carryMatches--;
                lit = true;
                UpdateLight();
                TextController.Get().ShowText("Finally some light!", Color.red, 4f);
            }
            else
            {
                TextController.Get().ShowText("This candle is no match for me!", Color.red, 4f);
            }
        }
        if (lit)
        {
            GameObject.Find("SafePoint").transform.position = gameObject.transform.position;
            if (playerController.Panic)
            {
                playerController.Panic = false;
                playerController.StopForceMovement();
                playerController.GetComponent<PanicController>().PanicLevel = 0;
            }
        }
    }
}
