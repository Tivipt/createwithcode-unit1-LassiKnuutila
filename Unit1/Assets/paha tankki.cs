using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pahatankki : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the object
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per physics frame (better for applying forces)
    void FixedUpdate()
    {
        // Apply force to move the object forward based on its local forward direction
        rb.AddForce(transform.forward * speed);
    }
}
