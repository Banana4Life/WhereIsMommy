﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchesController : CollisionController
{
    public int amount = 2;
    protected override void handle(PlayerController playerController)
    {
        gameObject.SetActive(false);
        playerController.Carry().carryMatches += amount;
        TextController.Get().ShowText("LET EVERYTHING BURN!!!!!!11", Color.red, 4f);
    }
}