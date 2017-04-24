using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorController : MonoBehaviour
{
    public String RequiredKey;
    public bool ClockWise = true;
    public float RotationSpeed = 45f;

    [Header("Audio")]
    public AudioClip[] DoorOpenSounds;
    public AudioClip[] DoorLockedSounds;
    public float DoorOpenSoundChance = 0.6f;
    public float SoundVolumeScale = 0.7f;

    // internal
    private bool isOpen = false;
    private bool changing = false;
    private Quaternion targetRotation;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (changing)
        {
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
            if (targetRotation == gameObject.transform.rotation)
            {
                changing = false;
            }
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        var keyHolder = other.gameObject.GetComponentInParent<KeyHolder>();
        if (!keyHolder)
        {
            return;
        }
        if (keyHolder.MayOpen(RequiredKey))
        {
            if (!isOpen && RequiredKey.Length != 0)
            {
                TextController.Get().ShowText("The key works!", TextController.red, 4f);
            }
            ChangeState(true);
        }
        else
        {
            PlaySoundLocked();
            TextController.Get().ShowText("It's locked!", TextController.red, 4f);
        }
    }

    private void PlaySoundOpened()
    {
        if (UnityEngine.Random.value <= DoorOpenSoundChance)
        {
            var clip = DoorOpenSounds[UnityEngine.Random.Range(0, DoorOpenSounds.Length)];
            audioSource.PlayOneShot(clip, SoundVolumeScale);
        }
    }

    private void PlaySoundLocked()
    {
        var clip = DoorLockedSounds[UnityEngine.Random.Range(0, DoorLockedSounds.Length)];
        audioSource.PlayOneShot(clip, SoundVolumeScale);
    }

    public void ChangeState(bool open)
    {
        if (open != isOpen)
        {
            if (open)
            {
                PlaySoundOpened();
            }
            isOpen = open;
            changing = true;
            var direction = 90 * (ClockWise && open ? 1 : -1);
            targetRotation = gameObject.transform.rotation * Quaternion.Euler(Vector3.up * direction);
        }
    }
}