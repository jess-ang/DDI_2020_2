using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUIPanel;
    // Start is called before the first frame update
    void Start()
    {
        inventoryUIPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            inventoryUIPanel.SetActive(!inventoryUIPanel.activeSelf);
        }
    }
}
