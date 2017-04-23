using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : CollisionController
{
    private Light statusLight;
    private char letter;
    private Texture texture;
    private Texture[] textures;

    // Use this for initialization
    void Start()
    {
        statusLight = GetComponentInChildren<Light>();
    }

    public void SetButtonLetter(char letter)
    {
        this.letter = letter;
        int textureOffset = 'A' - letter;
        texture = textures[textureOffset];
    }

    protected override void handle(PlayerController playerController)
    {
        //playerController.OnButtonPressed(letter);
    }
}