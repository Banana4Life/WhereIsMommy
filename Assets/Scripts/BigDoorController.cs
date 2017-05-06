using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BigDoorController : CollisionController
{

    public int needPassed = 3;
    public GameObject blend;

    private float blendSpeed = 0.1f;
    private bool triggered;

	void Update () {
	    if (triggered)
	    {
	        Color oldColor = blend.GetComponent<Image>().color;
	        blend.GetComponent<Image>().color = new Color(oldColor.r, oldColor.g, oldColor.b, oldColor.a + blendSpeed);

	        if (blend.GetComponent<Image>().color.a + blendSpeed > 1)
	        {
	            SceneManager.LoadScene("End");
	        }
	    }
	}

    protected override void handle(PlayerController pc)
    {
        if (pc.buttonsPressed == PlayerController.charSet.Length)
        {
            triggered = true;
        }
        else
        {
            TextController.Get().ShowText("Its too heavy to move!", Color.red, 5f);
        }
    }
}
