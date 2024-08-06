using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// This is a class containing the logic for chacters to deal 
/// damage to another object/character.
/// This contains a damage function to deal damage to the object 
/// as well as a knockback fuction to move the object back in the 
/// direction of the hit.
/// </summary>

public class Combat : CoreComponent, IDamageable, IKnockBackable
{
    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }
    private Stats Stats { get => stats ??=  core.GetCoreComponent<Stats>(); }

    private Movement movement;
    private CollisionSenses collisionSenses;
    private Stats stats;

    #region Variables + Properties
    private float maxKnockbackTime = 0.2f;

    private bool isKnockBackActive;
    private float knockBackStartTime;
    #endregion

    #region Functions
    public override void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Damage(float amount)
    {
        //Debug.Log(core.transform.parent.name + " damaged " + amount);
        Stats?.DecreaseHealth(amount);
    }

    public void Knockback(Vector2 angle, float strength, int direction)
    {
        //Currently not working as intended. 
        //core.Movement.SetKnockbackVelocity(strength, angle, direction);


        Movement.CanSetVelocity = false;
        isKnockBackActive = true;
        knockBackStartTime = Time.time;

    }

    private void CheckKnockback()
    {
        if(isKnockBackActive && ((Movement?.CurrentVelocity.y <= 0.01f && CollisionSenses.isGroundedBool) || Time.time >= knockBackStartTime + maxKnockbackTime)) 
        {
            isKnockBackActive = false;
            Movement.CanSetVelocity = true;
        }
    }
    #endregion
}
