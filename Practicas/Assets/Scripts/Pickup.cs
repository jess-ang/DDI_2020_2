using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    private Inventory inventory;
    public Item item;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        
        if(inventory == null)
        {
            Debug.LogWarning("No se encontró el inventario");
        }    
    }

    public override void Interact()
    {
        Debug.Log("Levantando item");
        if (!source.isPlaying)
        {
            source.Play();
        }
        if(item.itemType!=ItemType.Money)
        {
            inventory.Add(item);
        }
        Destroy(gameObject,0.7f);
    }
}
