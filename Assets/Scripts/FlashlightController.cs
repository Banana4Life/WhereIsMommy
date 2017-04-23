using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : CollisionController {

    public GameObject textController;

    protected override void handle(PlayerController playerController)
    {
        gameObject.SetActive(false);
        playerController.carryLight = true;
        textController.GetComponent<TextController>().ShowText("Just a little more light! I hope the batteries don't run out.", Color.red, 4f);
    }
}
