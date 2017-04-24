using UnityEngine;

public class FlashlightController : CollisionController
{
    public bool legendary = false;

    public AudioClip pickupSound;

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
        TextController.Get().ShowText("Just a little more light! I hope the batteries don't run out.", TextController.red, 4f);
        playerController.gameObject.GetComponent<AudioSource>().PlayOneShot(pickupSound);
    }
}
