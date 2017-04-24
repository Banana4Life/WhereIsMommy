using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : CollisionController
{
    public Material[] Materials;
    public GameObject Letter;

    private Light statusLight;
    private char letterChar;

    // Use this for initialization
    void Start()
    {
        statusLight = GetComponentInChildren<Light>();
        statusLight.enabled = false;
    }

    public void SetButtonLetter(char newLetter)
    {
        letterChar = newLetter;
        int materialOffset = newLetter - 'A';
        var material = Materials[materialOffset];
        var letterRenderer = Letter.GetComponent<Renderer>();
        letterRenderer.material = material;
    }

    protected override void handle(PlayerController playerController)
    {
        var correctOrder = playerController.OnButtonPress(letterChar);
        EnableLight(correctOrder);
        PlaySound(correctOrder);

    }

    private void PlaySound(bool good)
    {
        // TODO implement me!
    }


    private void EnableLight(bool good)
    {
        statusLight.color = good ? Color.green : Color.red;
        statusLight.enabled = true;
        if (!IsInvoking("DisableLight"))
        {
            Invoke("DisableLight", 3f);
        }
    }

    private void DisableLight()
    {
        statusLight.enabled = false;
    }
}