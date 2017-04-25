public class SweetsController : CollisionController
{

    private PlayerController pc;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void handle(PlayerController playerController)
    {
        playerController.ForceMovement(gameObject.transform.position);
        pc = playerController;
        TextController.Get().ShowText("Mhhm. Sweets!", TextController.red, 2f);
        Invoke("StopEating", 2f);
    }

    private void StopEating()
    {
        pc.StopForceMovement();
        gameObject.SetActive(false);
        Invoke("StopSugarRush", 10f);
        pc.sugarRush = true;
    }

    private void StopSugarRush()
    {
        pc.sugarRush = false;
    }


}
