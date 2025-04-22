using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;           // Forward/backward speed of the car
    public float turnSpeed = 100f;      // Turning speed of the car

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the car for physics-based movement
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement controls using I, J, K, L keys
        float moveForward = 0f;
        float turn = 0f;

        // Check for vertical movement (I/K for forward/backward)
        if (Input.GetKey(KeyCode.I))   // Move forward (I key)
        {
            moveForward = 1f;
        }
        if (Input.GetKey(KeyCode.K))   // Move backward (K key)
        {
            moveForward = -1f;
        }

        // Check for horizontal movement (J/L for left/right turn)
        if (Input.GetKey(KeyCode.J))   // Turn left (J key)
        {
            turn = -1f;
        }
        if (Input.GetKey(KeyCode.L))   // Turn right (L key)
        {
            turn = 1f;
        }

        // Move the car forward or backward based on input
        Vector3 movement = transform.forward * moveForward * speed * Time.deltaTime;

        // Apply the movement to the Rigidbody
        rb.MovePosition(transform.position + movement);

        // Rotate the car based on horizontal input (left/right)
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
    }
}
