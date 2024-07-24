using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTestGoblin : MonoBehaviour, IDamageable
{
    private Animator animator;

    public void Damage(float amount)
    {
        //Destroy(gameObject);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
