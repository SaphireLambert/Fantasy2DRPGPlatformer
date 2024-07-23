using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int amountOfJumpsLeft;
    public PlayerJumpState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName) : base(player, stateMachiene, playerData, animBoolName)
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();
        core.Movement.SetVelocityY(playerData.jumpVelocity);
        player.InAirState.SetIsJumping();
        isAbilityDone = true;
        DecreaseAmountOfJumpsLeft();
    }

    public bool CanJump()
    {
        if(amountOfJumpsLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RestAmountOfJumps()
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    }

    public void DecreaseAmountOfJumpsLeft() => amountOfJumpsLeft--;

}
