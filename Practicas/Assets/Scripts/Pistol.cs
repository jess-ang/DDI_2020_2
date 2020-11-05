using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Pistol", menuName = "Inventario/Weapon/Pistol")]

public class Pistol : Item
{
    public float reloadTime = 0.5f;
    public int maxCapacity = 7;
    public float caliber = 10f;
        public int energyPoints = 10;

        private GameObject player;

    public override void Use()
    {

        Debug.Log("Shooting pistol "+name+". Reloading in "+reloadTime);

                player = GameObject.Find("MainPlayer");
        Health health = player.GetComponent<Health>();
        if (health != null)
        {
        Debug.Log("Eating " +name+ ". Increasing energy: +" +energyPoints);
            health.ModifyHealth(-energyPoints);
        }
    } 
}
