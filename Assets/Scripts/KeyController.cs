using UnityEngine;

public class KeyController : CollisionController
{
    public string keyName;

    public AudioClip pickupSound;

    protected override void handle(PlayerController playerController)
    {
        gameObject.SetActive(false);
        var keyHolder = playerController.gameObject.GetComponent<SpecificKeyHolder>();
        keyHolder.key.Add(keyName);
        switch (keyName)
        {
            case "Key1":
                playerController.Carry().carryKey1 = true;
                break;
            case "Key2":
                playerController.Carry().carryKey2 = true;
                break;
            case "Key3":
                playerController.Carry().carryKey3 = true;
                break;
        }

        TextController.Get().ShowText("I found a key!", TextController.red, 4f);
        playerController.gameObject.GetComponent<AudioSource>().PlayOneShot(pickupSound);
    }
}
