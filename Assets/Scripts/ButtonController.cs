using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : CollisionController
{
    public Texture[] Textures;

    private Texture texture;
    private Light statusLight;
    private char letter;

    // Use this for initialization
    void Start()
    {
        statusLight = GetComponentInChildren<Light>();
        statusLight.enabled = false;
    }

    public void SetButtonLetter(char newLetter)
    {
        letter = newLetter;
        int textureOffset = letter - 'A';
        texture = Textures[textureOffset];
    }

    protected override void handle(PlayerController playerController)
    {
        var correctOrder = playerController.OnButtonPress(letter);
        EnableLight(correctOrder);
        PlaySound(correctOrder);

    }

    private void PlaySound(bool good)
    {
        // TODO implement me!
    }


    private void EnableLight(bool good)
    {
        statusLight.color = good ? Color.red : Color.green;
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