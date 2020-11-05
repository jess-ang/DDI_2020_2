using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyModifier : MonoBehaviour
{
    public float deltaHp;
    
    void OnTriggerStay(Collider other)
    {
        Energy energy = other.GetComponent<Energy>();
        Debug.Log("Colision!!!");
        if (energy != null)
        {
            Debug.Log("Energia asognada!!!");
            energy.ModifyEnergy(deltaHp * Time.deltaTime);
        }
    }
}
