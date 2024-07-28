using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AgressiveWeapon : Weapon
{
    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    protected SO_AgressiveWeaponData agressiveWeaponData;

    private List<IDamageable> detectedDamageable = new List<IDamageable>();
    private List<IKnockBackable> detectedKnowckbackable = new List<IKnockBackable>();   

    protected override void Awake()
    {
        base.Awake();

        if(weaponData.GetType() == typeof(SO_AgressiveWeaponData))
        {
            agressiveWeaponData = (SO_AgressiveWeaponData)weaponData;
        }
        else
        {
            Debug.LogError("Wrong Data for weapon");
        }
    }
    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        CheckMeleeAttack();
    }
    private void CheckMeleeAttack()
    {
        AttackDetails attackDetails = agressiveWeaponData.AttackDetails[attackCounter];

        foreach (IDamageable item in detectedDamageable.ToList())
        {
            item.Damage(attackDetails.damageAmount);
        }
        foreach (IKnockBackable item in detectedDamageable.ToList())
        {
            item.Knockback(attackDetails.knockBackAngle, attackDetails.knockBackStrength, Movement.FacingDirection);
        }
    }

    public void AddToDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            detectedDamageable.Add(damageable);
        }

        IKnockBackable knockBackable = collision.GetComponent<IKnockBackable>();

        if(knockBackable != null)
        {
            detectedKnowckbackable.Add(knockBackable);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            detectedDamageable.Remove(damageable);
        }

        IKnockBackable knockBackable = collision.GetComponent<IKnockBackable>();

        if (knockBackable != null)
        {
            detectedKnowckbackable.Remove(knockBackable);
        }
    }
}
