using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndMove : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrabbed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isGrabbed)
        {
            rb.isKinematic = true;  // Temporarily disable physics
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Example: Move with mouse
        }
        else
        {
            rb.isKinematic = false; // Enable physics again
        }
    }

    void OnMouseDown()
    {
        isGrabbed = true;
    }

    void OnMouseUp()
    {
        isGrabbed = false;
    }
}

