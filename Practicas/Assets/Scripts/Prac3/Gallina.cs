using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallina : Interactable
{
    Rigidbody rb;
    public Vector3 jumpDirection;
    public float jumpForce = 30f;
    private AudioSource source;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();
        if (rb != null)
        {
            source.Play();
            Debug.Log("Audio");
            //Destroy(gameObject,1);
            rb.AddForce(jumpDirection * jumpForce, ForceMode.Force);
        }
    }
}
