using UnityEngine;

public class obstacle_damage : MonoBehaviour
{
    public Transform startPoint;  // Reference to the start position (drag in the Inspector)
    public float resetDelay = 1f; // Delay before resetting the car's position (optional)

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger zone is tagged as ResetObject
        if (other.CompareTag("ResetObject"))
        {
            // Invoke the reset action after a delay
            Invoke(nameof(ResetCarPosition), resetDelay);
        }
    }

    void ResetCarPosition()
    {
        // Move the car back to the starting point
        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;  // Optional: Reset rotation to the starting point

    }
}
