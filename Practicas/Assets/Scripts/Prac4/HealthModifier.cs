using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof (Collider))]
public class HealthModifier : MonoBehaviour
{
    public float deltaHp;
    
    void OnTriggerStay(Collider other)
    {
                Debug.Log("Colision!!!");

        Health health = other.GetComponent<Health>();
        if (health != null)
        {
                        Debug.Log("health asognada!!!");

            health.ModifyHealth(deltaHp * Time.deltaTime);
        }
    }
}
