using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : Interactable
{
    Rigidbody rb;
    private AudioSource source;
    private float speed;
    private GameObject player;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        speed = 100;
    }

    void FixedUpdate ()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
	}

    public override void Interact()
    {
        base.Interact();
        if (!source.isPlaying)
        {
            source.Play();
        }
        player = GameObject.Find("MainPlayer");
        Money money = player.GetComponent<Money>();
        if (money != null)
        {
            money.ModifyMoney(10);
        }
        Destroy(gameObject,0.7f);

    }
}
