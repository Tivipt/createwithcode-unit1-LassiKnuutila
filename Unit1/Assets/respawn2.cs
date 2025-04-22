using UnityEngine;

public class respawn2 : MonoBehaviour
{
    private Rigidbody rb; // Reference to the Rigidbody of the current object (if you're using physics)
    private bool isMoving = true; // Flag to control movement in case you're using custom movement

    void Start()
    {
        // Try to get the Rigidbody attached to this object, if it exists
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("No Rigidbody found. Custom movement might be in use.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug: Check when trigger happens
        Debug.Log("Trigger detected with: " + other.gameObject.name);

        // Check if the object that the current object entered the trigger zone with has the tag "ResetObject"
        if (other.CompareTag("ResetObject"))
        {
            Debug.Log("Entered trigger zone of ResetObject, stopping the object.");
            StopObject();
        }
    }

    private void StopObject()
    {
        // If the object has a Rigidbody, stop its movement
        if (rb != null)
        {
            // Stop the Rigidbody's velocity and angular velocity
            rb.velocity = Vector3.zero; // Stops linear movement
            rb.angularVelocity = Vector3.zero; // Stops any rotation
            Debug.Log("Object stopped using Rigidbody.");
        }
        else
        {
            // If no Rigidbody is attached, stop movement manually
            isMoving = false;
            Debug.Log("Object stopped manually (no Rigidbody found).");
        }
    }

    void Update()
    {
        // Custom movement logic (e.g., if you were using transform.Translate)
        if (!isMoving)
        {
            // Add a custom stop behavior if using non-physics movement
            // Ensure that the object doesn't move anymore
            transform.Translate(Vector3.zero); // This is just an example; stop your custom movement here
            Debug.Log("Custom movement stopped.");
        }
    }
}
