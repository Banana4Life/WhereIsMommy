using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : CollisionController {

    protected override void handle(PlayerController playerController)
    {
        gameObject.SetActive(false);
        playerController.carryLight = true;
        // TODO show StoryText
    }
}
