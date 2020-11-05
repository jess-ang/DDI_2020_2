using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : Interactable
{
    Rigidbody rb;
    private AudioSource source;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Recogiendo moneda...");
        if (!source.isPlaying)
        {
            source.Play();
        }
        Destroy(gameObject,1f);
    }
}
