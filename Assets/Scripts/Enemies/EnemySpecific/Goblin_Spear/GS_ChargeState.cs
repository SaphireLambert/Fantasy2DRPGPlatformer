using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_ChargeState : EnemyChargeState
{
    private Goblin_Spear goblin_Spear; //This is called enemy in tutorial series
    public GS_ChargeState(Entity entity, EnemiesFiniteStateMachiene stateMachine, string animBoolName, D_EnemyChargeState stateData, Goblin_Spear goblin_Spear) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.goblin_Spear = goblin_Spear;
    }

    public override void DoChecks()
    {
        base.DoChecks();
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

        if(!isDetectingLedge || isDetectingWall)
        {
            stateMachine.ChangeState(goblin_Spear.lookForPlayerState);
        }
        else if (isChargeTimeOver)
        {
            if (performCloseRangeAction)
            {
                stateMachine.ChangeState(goblin_Spear.attackState);
            }
            else if(isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(goblin_Spear.detectedPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
