
using UnityEngine;

public class auton_liike : MonoBehaviour
{
    public float acceleration = 1500f;  // How fast the car accelerates
    public float steering = 300f;      // How fast the car steers
    public float maxSpeed = 30f;       // Maximum speed the car can reach
    public float brakeForce = 3000f;   // How strong the brakes are

    private float moveInput;
    private float steerInput;
    private float currentSpeed;
    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // Input for moving forward or backward (W/S or Up/Down arrow keys)
        moveInput = Input.GetAxis("Vertical");

        // Input for steering (A/D or Left/Right arrow keys)
        steerInput = Input.GetAxis("Horizontal");

        // Current speed of the car
        currentSpeed = rb.velocity.magnitude;

        // Brake logic (if the car goes too fast, apply brakes)
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyBrakes();
        }
    }

    void FixedUpdate()
    {
        // Apply acceleration based on the move input
        if (currentSpeed < maxSpeed)
        {
            rb.AddForce(transform.forward * moveInput * acceleration * Time.deltaTime);
        }

        // Apply steering based on the steer input
        transform.Rotate(0, steerInput * steering * Time.deltaTime, 0);
    }

    void ApplyBrakes()
    {
        // Apply brake force in the opposite direction of current velocity
        rb.AddForce(-rb.velocity.normalized * brakeForce * Time.deltaTime);
    }
}
