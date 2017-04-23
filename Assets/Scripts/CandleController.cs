using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : CollisionController
{
    public GameObject textContoller;

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
        if (playerController.carryMatches > 0)
        {
            playerController.carryMatches--;
            lit = true;
            UpdateLight();
            textContoller.GetComponent<TextController>().ShowText("Finally some light!", Color.red, 4f);
        }
        else
        {
            textContoller.GetComponent<TextController>().ShowText("This candle is no match for me!", Color.red, 4f);
        }
    }
}
