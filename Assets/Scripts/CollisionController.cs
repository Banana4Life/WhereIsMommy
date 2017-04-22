using UnityEngine;

public abstract class CollisionController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        var playerController = other.gameObject.GetComponentInParent<PlayerController>();
        if (playerController != null)
        {
            handle(playerController);
        }
    }

    protected abstract void handle(PlayerController playerController);
}
