using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName) : base(player, stateMachiene, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(xinput != 0)
        {
            stateMachiene.ChangeState(player.MoveState);
        }
        if(isAnimationFinished)
        {
            stateMachiene.ChangeState(player.IdleState);
        }
    }
}
