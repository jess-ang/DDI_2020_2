using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Food", menuName = "Inventario/Healing/Food")]

public class Food : Item
{
    public int energyPoints = 10;
    private GameObject player;
    public override void Use()
    {
        player = GameObject.Find("MainPlayer");        
        Energy energy = player.GetComponent<Energy>();
        Debug.Log("Eating " +name+ ". Increasing energy: +" +energyPoints);
        if (energy != null)
        {
            energy.ModifyEnergy(energyPoints);
        }
    } 
}
