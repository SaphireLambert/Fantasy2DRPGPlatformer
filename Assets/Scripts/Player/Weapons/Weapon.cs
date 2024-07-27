using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    protected SO_WeaponData weaponData;

    protected Animator bodyAnimator;
    protected Animator weaponAnimator;

    protected PlayerAttackState attackState;

    protected Core core;

    protected int attackCounter;

    protected virtual void Awake()
    {
        bodyAnimator = transform.Find("Body").GetComponent<Animator>();
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        if (attackCounter >= weaponData.amountOfAttacks)
        {
            attackCounter = 0;
        }

        bodyAnimator.SetBool("Attack", true);
        weaponAnimator.SetBool("Attack", true);

        bodyAnimator.SetInteger("Attack Counter", attackCounter);
        weaponAnimator.SetInteger("Attack Counter", attackCounter);
    }
    public virtual void ExitWeapon()
    {
        bodyAnimator.SetBool("Attack", false);
        weaponAnimator.SetBool("Attack", false);

        attackCounter++;

        gameObject.SetActive(false);
    }

    public virtual void AnimationStartMovementTrigger()
    {
        attackState.SetPlayerVelocity(weaponData.movementSpeed[attackCounter]);
    }
    public virtual void AnimationStopMovementTrigger()
    {
        attackState.SetPlayerVelocity(0f);
    }

    public virtual void AnimationTurnOffFlipTrigger()
    {
        attackState.SetFlipCheck(false);
    }

    public virtual void AnimationTurnOnFlipTrigger()
    {
        attackState.SetFlipCheck(true);
    }
    #region Animation Triggers

    public virtual void AnimationFinishTrigger()
    {
        attackState.AnimationFinishTrigger();
    }

    public virtual void AnimationActionTrigger()
    {

    }

    #endregion

    public void InitialiseWeapon(PlayerAttackState attackState, Core core)
    {
        this.attackState = attackState;
        this.core = core;
    }
}
