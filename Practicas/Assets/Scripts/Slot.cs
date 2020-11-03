using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    public Image image;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        if(inventory == null)
        {
            return;
        }
        if(item != null)
        {
            image.sprite  = item.icon;
        }
    }

    public void SetItem(Item item)
    {
        this.item = item;
        image.sprite  = item.icon;
    }

    public void Clear()
    {
        this.item = null;
        image.sprite = null;
    }
}
