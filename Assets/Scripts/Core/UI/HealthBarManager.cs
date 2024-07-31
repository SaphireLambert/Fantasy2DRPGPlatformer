using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{

    private Slider healthBarSlider;

    private void Start()
    {
        healthBarSlider = GetComponentInChildren<Slider>();
    }

    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        healthBarSlider.value = currentHealth / maxHealth;
    }
}
