using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockBackable
{
    private bool isKnockBackActive;
    private float knockBackStartTime;

    public void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Damage(float amount)
    {
        Debug.Log(core.transform.parent.name + " damaged " + amount);
    }

    public void Knockback(Vector2 angle, float strength, int direction)
    {
        //Currently not working as intended. 
        //core.Movement.SetKnockbackVelocity(strength, angle, direction);
        core.Movement.CanSetVelocity = false;
        isKnockBackActive = true;
        knockBackStartTime = Time.time;

    }

    private void CheckKnockback()
    {
        if(isKnockBackActive && core.Movement.CurrentVelocity.y <= 0.01f && core.CollisionSenses.isGroundedBool) 
        {
            isKnockBackActive = false;
            core.Movement.CanSetVelocity = true;
        }
    }

}
