using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public float energy = 100f;
    private float _minEnergy, _maxEnergy;
    private bool _enableAttack;
    private int _energyLoss; 
    public GameObject[] energyAware;

    void Start()
    {
        _minEnergy = 0f;
        _maxEnergy = energy;
        _enableAttack = true;
        _energyLoss = -10;
        InitializeEnergy(_maxEnergy);
    }

    void Update()
    {
        Attack();
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
            _enableAttack = false;
        else if (energy < _maxEnergy) 
        {
            SetEnergy(energy);
            _enableAttack = true;
        }
    }

    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(_enableAttack)
            {
                Debug.Log("Atacando con poder especial!");
                ModifyEnergy(_energyLoss);    
            }
            else
            {
                Debug.Log("No tengo energía para atacar");
            }

        }    
    }
}