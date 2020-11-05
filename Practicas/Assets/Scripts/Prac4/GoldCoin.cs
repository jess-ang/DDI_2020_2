using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : Interactable
{
    Rigidbody rb;
    private AudioSource source;
    private GameObject player;

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
        player = GameObject.Find("MainPlayer");
        Money money = player.GetComponent<Money>();
        if (money != null)
        {
        Debug.Log("SUmando dinero");
            money.ModifyMoney(10);
        }
        Destroy(gameObject,1f);

    }
}
