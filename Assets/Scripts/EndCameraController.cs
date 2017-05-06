using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCameraController : MonoBehaviour
{

    public GameObject camera;
    public GameObject girl;

    public GameObject creditBlend;
    public GameObject text;
    public GameObject faces;
    public GameObject restartButton;
    public GameObject exitButton;

    private Vector3 targetPosition = new Vector3(0, 70, -80);
    private Vector3 velocityMovement = Vector3.zero;
    private float velocityRotationX;
    private float velocityRotationZ;
    private float timeLeft = 2f;

    private float timeLeftToCredits = 9f;

    private Vector3 girlTargetPosition = new Vector3(-0.21f, 39.7f, -30.987f);
    private float girlWalkingOutTime = 1.3f;

    private float creditBlendTime = 0.7f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (girlWalkingOutTime > 0)
	    {
	        girlWalkingOutTime -= Time.deltaTime;

	        girl.transform.position = Vector3.Lerp(girl.transform.position, girlTargetPosition, Time.deltaTime / girlWalkingOutTime);
	    }
	    else
	    {
	        timeLeft -= Time.deltaTime;
	        if (timeLeft < 0)
	        {
	            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocityMovement, 2f);
	            camera.transform.rotation = Quaternion.Euler(
	                new Vector3(Mathf.SmoothDampAngle(camera.transform.eulerAngles.x, 25f, ref velocityRotationX, 1f), 0, Mathf.SmoothDampAngle(camera.transform.eulerAngles.z, 45f, ref velocityRotationZ, 2f)));
	            timeLeftToCredits -= Time.deltaTime;
	            if (timeLeftToCredits < 0)
	            {
	                creditBlendTime -= Time.deltaTime;
                    faces.SetActive(true);
	                Color oldColor = creditBlend.GetComponent<Image>().color;
	                creditBlend.GetComponent<Image>().color = new Color(oldColor.r, oldColor.g, oldColor.b, Mathf.Min(0.7f - creditBlendTime, 0.7f) / 0.7f);
	                if (creditBlendTime < 0)
	                {
	                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	                    Cursor.visible = true;
	                    Cursor.lockState = CursorLockMode.None;
	                    text.SetActive(true);
	                    restartButton.SetActive(true);
	                    exitButton.SetActive(true);
	                }
	            }
	        }
	    }
	}

    public void OnRestart()
    {
        SceneManager.LoadScene("Intro");
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
