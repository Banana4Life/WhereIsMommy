using UnityEngine;

public class CandleController : CollisionController
{
    public bool lit;

    private AudioSource audioSource;


    void Start()
    {
        UpdateLight();
        audioSource = GetComponent<AudioSource>();
    }

    void UpdateLight()
    {
        var lights = gameObject.GetComponentsInChildren<Light>();
        foreach (var light in lights)
        {
            light.enabled = lit;
        }
        var particleSystem = GetComponentInChildren<ParticleSystem>();
        if (particleSystem != null)
        {
            particleSystem.gameObject.SetActive(lit);
        }
    }


    protected override void handle(PlayerController playerController)
    {
        if (!lit)
        {
            if (playerController.Carry().carryMatches > 0)
            {
                playerController.Carry().carryMatches--;
                lit = true;
                UpdateLight();
                audioSource.Play();
                var matchCount = playerController.Carry().carryMatches;
                if (matchCount == 1)
                {
                    TextController.Get().ShowText("Only one match left!", TextController.red, 4f);
                }
                else if (matchCount == 0)
                {
                    TextController.Get().ShowText("Thats was my last match!", TextController.red, 4f);
                }
                else
                {
                    TextController.Get().ShowText("Finally some light! " + matchCount + " matches left.", TextController.red, 4f);
                }
            }
            else
            {
                TextController.Get().ShowText("I need more matches!", TextController.red, 4f);
            }
        }
        if (lit)
        {
            GameObject.Find("SafePoint").transform.position = gameObject.transform.position;
            if (playerController.Panic)
            {
                playerController.Panic = false;
                playerController.StopForceMovement();
                playerController.GetComponent<PanicController>().PanicLevel = 0;
            }
        }
    }
}
