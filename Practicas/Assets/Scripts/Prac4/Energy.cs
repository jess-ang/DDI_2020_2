using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public float energy = 100f;
    private float _minEnergy, _maxEnergy;
    public GameObject[] energyAware;

    void Start()
    {
        _minEnergy = 0f;
        _maxEnergy = energy;
        InitializeEnergy(_maxEnergy);
    }

    private void InitializeEnergy(float maxEnergy)
    {
        foreach (GameObject go in energyAware)
        {
            go.SendMessage(nameof(InitializeEnergy), maxEnergy, SendMessageOptions.DontRequireReceiver);
        }
    }

    private void SetEnergy(float newEnergy)
    {
        foreach (GameObject go in energyAware)
        {
            go.SendMessage(nameof(SetEnergy), newEnergy, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void ModifyEnergy(float delta)
    {
        energy = Mathf.Clamp(energy += delta, _minEnergy, _maxEnergy);
     if (energy <= 0) 
            DisableAttack();
        else if (energy < _maxEnergy) 
            SetEnergy(energy);
    }

    private void DisableAttack()
    {
        Debug.Log("Poder deshabilitado!!!");
        // Time.timeScale = 0f;
    }
}