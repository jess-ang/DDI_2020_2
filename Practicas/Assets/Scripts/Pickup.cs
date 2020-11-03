using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    private Inventory inventory;
    public Item item;

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
        inventory.Add(item);
        Destroy(gameObject);
    }
}
