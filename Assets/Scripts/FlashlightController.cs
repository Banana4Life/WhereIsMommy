using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : CollisionController
{
    public bool legendary = false;

    protected override void handle(PlayerController playerController)
    {
        gameObject.SetActive(false);
        if (legendary)
        {
            playerController.Carry().carryUvLight = true;
        }
        else
        {
            playerController.Carry().carryLight = true;
        }
        TextController.Get().ShowText("Just a little more light! I hope the batteries don't run out.", Color.red, 4f);
    }
}
