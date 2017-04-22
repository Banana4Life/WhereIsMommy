using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyController : CollisionController
{
    public GameObject teddyText;
    public GameObject textHider;

    private float teddyTextTimeLeft = 0;

    protected override void handle(PlayerController playerController)
    {
        gameObject.SetActive(false);
        playerController.carryTeddy = true;
        textHider.GetComponent<TextHider>().HideTextIn(teddyText, 4f);
        teddyText.SetActive(true);
    }
}
