using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallina : Interactable
{
    Rigidbody rb;
    public Vector3 jumpDirection;
    public float jumpForce = 30f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Interact()
    {
        base.Interact();
        if (rb != null)
        {
            rb.AddForce(jumpDirection * jumpForce, ForceMode.Force);
        }
    }
}
