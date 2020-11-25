using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallina : MonoBehaviour
{
    protected AudioSource source;
    Rigidbody rb;
    public Vector3 jumpDirection;
    public float jumpForce = 30f;
    // private GameObject player;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
        if (rb != null)
        {
            rb.AddForce(jumpDirection * jumpForce, ForceMode.Force);
            Debug.Log("Gallina saltando...");
        }
        // player = GameObject.Find("MainPlayer");
        // HenScore henScore = player.GetComponent<HenScore>();
        // if (henScore != null)
        // {
        //     henScore.ModifyHenScore();
        // }
        // Destroy(gameObject,0.7f);
    }
}