using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public GameObject teddy;
    public GameObject flashlight;

    [Header("Settings")]
    public float Thrust = 2000;
    public float Epsilon = 0.1f;
    public float maxVelocity = 15f;
    public float maxHighVelocity = 25f;
    public int velocity;
    public bool Panic = false;

    [Header("State")]
    public bool carryTeddy;
    public bool carryLight;
    public int carryMatches = 0;

    private ModelCycler modelCycler;
    private Rigidbody rigidBody;
    private NavMeshAgent navAgent;

    public bool forceMovement;
    public bool sugarRush;

    // Use this for initialization
    void Start()
    {
        forceMovement = false;
        carryTeddy = false;
        carryLight = false;
        carryMatches = 0;
        modelCycler = GetComponentInChildren<ModelCycler>();
        rigidBody = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInternalVelocity();
        UpdateAnimationSpeed();

        TurnLightOnOff();
        CarryTeddy();

        if (!forceMovement)
        {
            RotateToMouse();

            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");

            if (Math.Abs(x) > Epsilon || Math.Abs(y) > Epsilon)
            {
                if (velocity < (sugarRush ? maxHighVelocity : maxVelocity))
                {
                    rigidBody.AddForce(new Vector3(x, 0, y).normalized * Thrust * Time.deltaTime);
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

    private void CarryTeddy()
    {
        teddy.SetActive(carryTeddy);
    }

    private void TurnLightOnOff()
    {
        flashlight.SetActive(carryLight);
    }

    private void RotateToMouse()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, 1 << 9)) // Level 9 = Floor
        {
            var hitPoint = hit.point;
            hitPoint.y = gameObject.transform.position.y;
            gameObject.transform.LookAt(hitPoint);
        }
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