using UnityEngine;

public class MatchesController : CollisionController
{
    public AudioClip[] audioClips;

    public int amount = 2;
    protected override void handle(PlayerController playerController)
    {
        PlaySound(playerController);
        gameObject.SetActive(false);

        if (playerController.Carry().carryMatches == 0)
        {
            TextController.Get().ShowText("Hmm more matches. (+" + amount + " matches)", TextController.red, 4f);
        }
        else
        {
            TextController.Get().ShowText("Now I can light a candle. (+" + amount + " matches)", TextController.red, 4f);
        }
        playerController.Carry().carryMatches += amount;
    }

    private void PlaySound(PlayerController player)
    {
        var clip = audioClips[Random.Range(0, audioClips.Length)];
        player.gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
