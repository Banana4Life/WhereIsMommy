public class BloodyTrailController : CollisionController {

    protected override void handle(PlayerController pc)
    {
        pc.bloodyTrail = true;
    }
}
