using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponent
{
    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private HealthBarManager healthBarManager;

    public event Action OnHealthZero;

    [SerializeField]
    private float maxHealth;
    private float currentHealth;

    protected override void Awake()
    {
        base.Awake();
        if (gameObject.CompareTag("Player"))
        {
            maxHealth = playerData.maxHealth;
            currentHealth = playerData.currentHealth;
        } 
        currentHealth = maxHealth;
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        healthBarManager.UpdateHealth(currentHealth, maxHealth);

        if(currentHealth <= 0)
        {
            currentHealth = 0;

            OnHealthZero?.Invoke();

            Debug.Log("Character has died (Health is 0)");
        }
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}
