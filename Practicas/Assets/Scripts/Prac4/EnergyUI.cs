using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    protected float maxHealth, currentHealth;
    private Image image;

    private void Awake()
    {
        Debug.Log("IMagen asignada!!!");
        image = GetComponent<Image>();
    }

    public void InitializeHealth(float health)
    {
        maxHealth = health;
        currentHealth = health;
    }

    public void SetHealth(float newHealth)
    {
        currentHealth = newHealth;
        float healthRatio = currentHealth / maxHealth;
        image.fillAmount = healthRatio;
    }
}
