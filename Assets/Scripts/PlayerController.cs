using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = System.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CarryScript))]
public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    public float Thrust = 2000;
    public float Epsilon = 0.1f;
    public float maxVelocity = 15f;
    public float maxHighVelocity = 25f;
    public int velocity;
    public bool Panic = false;
    public AudioMixer mixer;
    public int rotationSpeed = 250;
    public int camRotationSpeed = 150;
    public GameObject trailPrefab;
    public bool bloodyTrail;

    [Header("Audio Sources")]
    public AudioSource voiceSource;
    public AudioSource stepSource;

    [Header("Audio Clips")]
    public AudioClip[] stepSounds;

    public static readonly char[] charSet = {'A', 'B', 'C', 'D'};
    public char[] combination;
    public int buttonsPressed = 0;

    private ModelCycler modelCycler;
    private Rigidbody rigidBody;
    private NavMeshAgent navAgent;
    private CarryScript carry;

    private char? lastButton;

    public bool forceMovement;
    public bool sugarRush;

    public GameObject bigDoor;
    public Mesh bigDoorOpen;
    public GameObject bigDoorPlane;
    public GameObject bigDoorSpotlight;

    private GameObject trail;
    private int stepCount = 0;

    private Quaternion targetRotation;

    // Use this for initialization
    void Start()
    {
        if (!Application.isEditor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        AudioListener.volume = 0.5f;
        var rand = new Random(DateTime.Now.Millisecond);
        combination = charSet.OrderBy(a => rand.Next()).ToArray();
        Debug.Log("The Combination is: " + GetCombinationString());
        var buttons = GameObject.FindGameObjectsWithTag("Button");
        for (var i = 0; i < combination.Length; ++i)
        {
            buttons[i].GetComponent<ButtonController>().SetButtonLetter(combination[i]);
        }
        forceMovement = false;
        buttonsPressed = 0;
        modelCycler = GetComponentInChildren<ModelCycler>();
        rigidBody = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();
        carry = GetComponent<CarryScript>();
        trail = GameObject.Find("Trail");
        bloodyTrail = false;
    }

    public string GetCombinationString()
    {
        return string.Join(" ", combination.Select(c => "" + c).ToArray());
    }

    private void OnModelCycle(int index)
    {
        AudioClip clip;
        if (index == 1)
        {
            clip = stepSounds[0];
            step(true);
        }
        else if (index == 3)
        {
            clip = stepSounds[1];
            step(false);
        }
        else
        {
            return;
        }
        stepSource.PlayOneShot(clip);
    }

    private void step(bool left)
    {
        if (bloodyTrail)
        {
            var step = Instantiate(trailPrefab);
            step.name = "Step " + stepCount++;
            step.transform.position = gameObject.transform.position + new Vector3(left ? 0.32f : -0.32f, 0.001f, 0);
            step.transform.rotation = gameObject.transform.rotation;
            step.transform.parent = trail.transform;
        }
    }

    public bool OnButtonPress(char letter)
    {
        if (lastButton == letter)
        {
            return buttonsPressed > 0;
        }
        lastButton = letter;
        if (combination[buttonsPressed] == letter)
        {
            buttonsPressed++;
            Debug.Log(letter + " Correct");
            if (buttonsPressed == charSet.Length)
            {
                Debug.Log("Exit is now Open");
                bigDoor.GetComponentInChildren<MeshFilter>().mesh = bigDoorOpen;
                bigDoor.GetComponent<AudioSource>().PlayDelayed(1f);
                bigDoorPlane.SetActive(true);
                bigDoorSpotlight.SetActive(true);
            }

            return true;
        }
        Debug.Log(letter + " Wrong");
        buttonsPressed = 0;
        return false;
    }

    public CarryScript Carry()
    {
        return carry;
    }

    private bool canClose = false;

    // Update is called once per frame
    void Update()
    {
        UpdateInternalVelocity();
        UpdateAnimationSpeed();
        UpdateSound();

        CheckClose();

        if (!forceMovement)
        {
            Rotate();

            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");

            if (Math.Abs(x) > Epsilon || Math.Abs(y) > Epsilon)
            {
                if (velocity < (sugarRush ? maxHighVelocity : maxVelocity))
                {
                    var dir = transform.TransformDirection(new Vector3(x, 0, y).normalized);
                    rigidBody.AddForce(dir * Thrust * Time.deltaTime);
                }
                // else ignore
            }
            else
            {
                var change = new Vector3(rigidBody.velocity.x / -2, 0, rigidBody.velocity.z / -2);
                rigidBody.AddForce(change, ForceMode.VelocityChange);
            }
        }

    }

    private void CheckClose()
    {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (canClose)
            {
                Application.Quit();
            }
            else
            {
                TextController.Get().ShowText("Press ESC again to leave her to die!", Color.white, 5f);
                canClose = true;
                Invoke("DoNotClose", 5f);
            }
        }
    }

    private void DoNotClose()
    {
        canClose = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (Application.isEditor)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        Cursor.visible = false;
    }

    private void UpdateSound()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        var volume = AudioListener.volume + scroll / 2;
        AudioListener.volume = Clamp(volume, 0, 1);
        if (scroll != 0)
        {
            TextController.Get().ShowText("Volume: " + (int)(AudioListener.volume * 100) + "%", Color.cyan, 1f);
        }
    }

    public static float Clamp(float value, float min, float max)
    {
        return (value < min) ? min : (value > max) ? max : value;
    }

    private void UpdateAnimationSpeed()
    {
        if (velocity > 0 && !modelCycler.IsCycling())
        {
            modelCycler.StartCycling();
        }
        else if (velocity < float.Epsilon && modelCycler.IsCycling())
        {
            modelCycler.StopCycling();
        }
        modelCycler.Speed = velocity / Math.Max(sugarRush ? maxHighVelocity : maxVelocity, navAgent.speed);
    }

    private void UpdateInternalVelocity()
    {
        velocity = (int)Math.Max(rigidBody.velocity.magnitude, navAgent.velocity.magnitude);
    }

    private void Rotate()
    {
        var mouseMovement = Input.GetAxisRaw("Mouse X");
        var rightStickMovement = Input.GetAxisRaw("Right Stick X Axis");
        var movement = rightStickMovement;
        if (Mathf.Abs(mouseMovement) > Mathf.Abs(rightStickMovement))
        {
            movement = mouseMovement;
        }

        var camWagon = GetComponent<CameraController>().cam.transform.parent;
        camWagon.RotateAround(transform.position, Vector3.up, movement * camRotationSpeed * Time.deltaTime);
        //gameObject.transform.RotateAround(transform.position, Vector3.Cross(transform.forward, Vector3.up), vertical * RotationSpeed * Time.deltaTime);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, camWagon.rotation, rotationSpeed * Time.deltaTime);
    }

    public void StopForceMovement()
    {
        if (Panic)
        {
            return;
        }
        forceMovement = false;
        navAgent.isStopped = true;
        navAgent.enabled = false;
    }

    public void ForceMovement(Vector3 target)
    {
        forceMovement = true;
        navAgent.enabled = true;
        navAgent.SetDestination(target);
        navAgent.isStopped = false;
    }

}