using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{

    [SerializeField]
    private Slider healthBarSlider;

    public void UpdateHealth(float currentHealth, float maxHealth)
    {

        healthBarSlider.value = currentHealth / maxHealth * 100;
    }
}
