// FlightController.cs 
// CENG 454 – HW1: Sky-High Prototype 
// Author: Berkay Halıcıoğlu | Student ID: 210444072 
 
using UnityEngine; 
 
public class FlightController : MonoBehaviour 
{ 
    [SerializeField] private float pitchSpeed  = 45f;  // degrees/second 
    [SerializeField] private float yawSpeed    = 45f;  // degrees/second 
    [SerializeField] private float rollSpeed   = 45f;  // degrees/second 
    [SerializeField] private float thrustSpeed = 5f;   // units/second 
 
    // TODO (Task 3-A): Declare a private Rigidbody field named 'rb'
    private Rigidbody rb; 
 
    void Start() 
    { 
        // TODO (Task 3-B): Cache GetComponent<Rigidbody>() into 'rb'.
        rb = GetComponent<Rigidbody>();
         
        //Then set rb.freezeRotation = true. 
        //Why is freezeRotation needed? Answer in your PDF. 
        rb.freezeRotation = true;
    } 
 
    void Update()// or FixedUpdate() 
    { 
        HandleRotation(); 
        HandleThrust(); 
    } 
 
    private void HandleRotation() 
    { 
        // TODO (Task 3-C): 
        // Pitch
        float pitchInput = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow
        transform.Rotate(Vector3.right * pitchInput * pitchSpeed * Time.deltaTime);

        // Yaw 
        float yawInput = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        transform.Rotate(Vector3.up * yawInput * yawSpeed * Time.deltaTime);

        // Roll
        float rollInput = 0f;
        if (Input.GetKey(KeyCode.Q)) // Q for rolling left
            rollInput = 1f;
        else if (Input.GetKey(KeyCode.E)) // E for rolling right
            rollInput = -1f;

        transform.Rotate(Vector3.forward * rollInput * rollSpeed * Time.deltaTime);    
 
    } 
 
    private void HandleThrust() 
    { 
        // TODO (Task 3-D): 
        if (Input.GetKey(KeyCode.Space)) // Space for thrust
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    } 
} 