using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeddyController : CollisionController
{
    public string text = "Now I have my teddy. I am ready to go.";

    private float teddyTextTimeLeft = 0;

    protected override void handle(PlayerController playerController)
    {
        gameObject.SetActive(false);
        TextController.Get().ShowText(text, TextController.red, 4f);
        playerController.Carry().carryTeddy = true;
    }
}
