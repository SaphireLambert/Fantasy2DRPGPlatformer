using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapon weapon;

    private int xInput;

    private float velocityToSet;

    private bool setVelocity;
    private bool shouldCheckFlip;
    public PlayerAttackState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName) : base(player, stateMachiene, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        setVelocity = false;

       weapon.EnterWeapon();
    }

    public override void Exit()
    {
        base.Exit();

        weapon.ExitWeapon();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        if(shouldCheckFlip)
        {
            core.Movement.CheckIfShouldFlip(xInput);
        }

        if (setVelocity)
        {
            core.Movement.SetVelocityX(velocityToSet * core.Movement.FacingDirection);
        }
    }

    public void SetWeapon(Weapon weapon) 
    {
        this.weapon = weapon;
        weapon.InitialiseWeapon(this);
    }

    public void SetPlayerVelocity(float velocity)
    {
        core.Movement.SetVelocityX(velocity * core.Movement.FacingDirection);

        velocityToSet = velocity;
        setVelocity = true;
    }
    public void SetFlipCheck(bool vaule)
    {
        shouldCheckFlip = vaule;
    }

    #region Animation Triggers

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }

    #endregion
}
