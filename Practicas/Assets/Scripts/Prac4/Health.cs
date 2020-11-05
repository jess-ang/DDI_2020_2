﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;
    private float _minHealth, _maxHealth;
    public GameObject[] healthAware;

    void Start()
    {
        _minHealth = 0f;
        _maxHealth = health;
        InitializeHealth(_maxHealth);
    }

    private void InitializeHealth(float maxHealth)
    {
        foreach (GameObject go in healthAware)
        {
            go.SendMessage(nameof(InitializeHealth), maxHealth, SendMessageOptions.DontRequireReceiver);
        }
    }

    private void SetHealth(float newHealth)
    {
        foreach (GameObject go in healthAware)
        {
            go.SendMessage(nameof(SetHealth), newHealth, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void ModifyHealth(float delta)
    {
        health = Mathf.Clamp(health += delta, _minHealth, _maxHealth);
        if (health <= 0) 
            Die();
        else if (health < _maxHealth) 
            SetHealth(health);
    }

    private void Die()
    {
        Debug.Log("Perdiste!!!");
        // Time.timeScale = 0f;
    }
}