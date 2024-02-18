using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarControl : MonoBehaviour
{
    private float SteeringInput;   
    private float MotorInput; 
    private float SteerAngle; 
    private bool Braking;

    [SerializeField] Rigidbody rb;

    [SerializeField] WheelCollider FLWC;
    [SerializeField] WheelCollider FRWC;
    [SerializeField] WheelCollider RLWC;
    [SerializeField] WheelCollider RRWC;

    [SerializeField] Transform FLWT;
    [SerializeField] Transform FRWT;
    [SerializeField] Transform RLWT;
    [SerializeField] Transform RRWT;

    [SerializeField] float MaxSteerAngle; 
    [SerializeField] float Gas; 
    [SerializeField] float Brake;

    [SerializeField] private List<Scene> _SceneList;


    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
        Steering();
        Motor();
        WheelUpdate();
        AddForceBody();
    }

    //tried simulating adding force to the body of the car, I'm not sure if it actually works
    private void AddForceBody()
    {
        rb.AddForce(Vector3.forward * Gas); 
        rb.AddForce(Vector3.left * Gas);
        rb.AddForce(Vector3.right * Gas);
        rb.AddForce(Vector3.back * Gas);
    }

    // Gets the WASD and space Inputs
    private void Movement()
    {
        SteeringInput = Input.GetAxis("Horizontal"); // gets A and D
        MotorInput = Input.GetAxis("Vertical"); // gets W and S
        Braking = Input.GetKey(KeyCode.Space); // Space
    }

    //Limits or constrains the steering to a certain angle only
    private void Steering()
    {
        SteerAngle = MaxSteerAngle * SteeringInput; // Limits steering to a certain angle only
        FRWC.steerAngle = SteerAngle; // Front Right Wheel steer angle
        FLWC.steerAngle = SteerAngle; // Front Left Wheel steer angle
    }

    //This helps the car propel forward or backward with the current settings and collliders, technically making the car a RWD
    private void Motor()
    {
        
        RRWC.motorTorque = MotorInput * Gas; //Rear right wheel will have gas applied
        RLWC.motorTorque = MotorInput * Gas; //Rear left wheel will have gas applied

        Brake = Braking ? 5000f : 0f;
        RRWC.brakeTorque = Brake;
        RLWC.brakeTorque = Brake;
    }

    // updates the wheel, makes it look like it's spinning or steering
    private void WheelUpdate()
    {
        WheelUpdatePos(FRWC, FRWT);
        WheelUpdatePos(FLWC, FLWT);
        WheelUpdatePos(RRWC, RRWT);
        WheelUpdatePos(RLWC, RLWT);
    }

    private void WheelUpdatePos(WheelCollider wheelcollider,Transform trans )
    {
        Vector3 pos;
        Quaternion rot;
        wheelcollider.GetWorldPose(out pos, out rot);
        trans.rotation = rot;
        trans.position = pos;
    }

    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
