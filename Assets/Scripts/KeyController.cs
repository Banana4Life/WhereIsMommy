using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : CollisionController
{
    public GameObject textController;
    public string keyName;

    protected override void handle(PlayerController playerController)
    {
        gameObject.SetActive(false);
        var keyHolder = playerController.gameObject.GetComponent<SpecificKeyHolder>();
        keyHolder.key.Add(keyName);
        textController.GetComponent<TextController>().ShowText("I found a key!", Color.red, 4f);
    }
}
