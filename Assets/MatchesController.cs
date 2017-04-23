using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchesController : CollisionController
{
    public GameObject textController;

    protected override void handle(PlayerController playerController)
    {
        gameObject.SetActive(false);
        playerController.carryMatches += 1;
        textController.GetComponent<TextController>().ShowText("LET EVERYTHING BURN!!!!!!11", Color.red, 4f);
    }
}
