public class TerminalController : CollisionController {

    protected override void handle(PlayerController pc)
    {
        TextController.Get().ShowText("The terminal reads: " + pc.GetCombinationString(), TextController.red, 10f);
    }
}
