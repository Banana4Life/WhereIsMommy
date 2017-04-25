using UnityEngine;

public class MatchesController : CollisionController
{
    public AudioClip[] audioClips;

    public int amount = 2;
    protected override void handle(PlayerController playerController)
    {
        PlaySound(playerController);
        gameObject.SetActive(false);
        playerController.Carry().carryMatches += amount;
        TextController.Get().ShowText("Now I can light a candle", TextController.red, 4f);
    }

    private void PlaySound(PlayerController player)
    {
        var clip = audioClips[Random.Range(0, audioClips.Length)];
        player.gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
