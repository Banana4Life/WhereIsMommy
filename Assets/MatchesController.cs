using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchesController : CollisionController
{
    protected override void handle(PlayerController playerController)
    {
        gameObject.SetActive(false);
        playerController.carryMatches += 1;
        TextController.Get().ShowText("LET EVERYTHING BURN!!!!!!11", Color.red, 4f);
    }
}
