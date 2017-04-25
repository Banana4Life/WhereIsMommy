using UnityEngine;
public class TeddyController : CollisionController
{
    private float teddyTextTimeLeft = 0;

    public AudioClip pickupSound;

    protected override void handle(PlayerController playerController)
    {
        gameObject.SetActive(false);
        TextController.Get().ShowText( "Now I have my teddy. I am ready to go.", TextController.red, 4f);
        playerController.Carry().carryTeddy = true;
        playerController.gameObject.GetComponent<AudioSource>().PlayOneShot(pickupSound);
    }
}
