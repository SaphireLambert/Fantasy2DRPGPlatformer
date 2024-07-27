using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_DetectedPlayer : EnemyDetectPlayerState
{
    private Goblin_Spear goblin_Spear; //Tutorial calls this enemy
    public GS_DetectedPlayer(Entity entity, EnemiesFiniteStateMachiene stateMachine, string animBoolName, D_EnemyDetectPlayer stateData, Goblin_Spear goblin_Spear) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.goblin_Spear = goblin_Spear;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(goblin_Spear.attackState);
        }
        else if(performLongRangeAction)
        {
            stateMachine.ChangeState(goblin_Spear.chargeState);
        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(goblin_Spear.lookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
