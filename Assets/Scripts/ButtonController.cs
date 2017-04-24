using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ButtonController : CollisionController
{
    public Material[] Materials;
    public GameObject Letter;

    private AudioSource audioSource;
    private Light statusLight;
    private char letterChar;

    // Use this for initialization
    void Start()
    {
        statusLight = GetComponentInChildren<Light>();
        statusLight.enabled = false;
        audioSource = GetComponent<AudioSource>();
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
        PlaySound();

    }

    private void PlaySound()
    {
        audioSource.Play();
    }


    private void EnableLight(bool good)
    {
        statusLight.color = good ? Color.green : Color.red;
        statusLight.enabled = true;
        if (!good && !IsInvoking("DisableLights"))
        {
            Invoke("DisableLights", 3f);
        }
    }

    private void DisableLights()
    {
        foreach (var button in GameObject.FindGameObjectsWithTag("Button"))
        {
            button.GetComponent<ButtonController>().statusLight.enabled = false;
        }
    }
}