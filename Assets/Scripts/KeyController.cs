using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : CollisionController
{
    public string keyName;

    protected override void handle(PlayerController playerController)
    {
        gameObject.SetActive(false);
        var keyHolder = playerController.gameObject.GetComponent<SpecificKeyHolder>();
        keyHolder.key.Add(keyName);
        TextController.Get().ShowText("I found a key!", Color.red, 4f);
    }
}
