using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockBackable
{
    public void Damage(float amount)
    {
        Debug.Log(core.transform.parent.name + " damaged " + amount);
    }

    public void Knockback(Vector2 angle, float strength, int direction)
    {
        core.Movement.SetKnockbackVelocity(strength, angle, direction);
        Debug.Log("KnockedBack"); 
    }
}
