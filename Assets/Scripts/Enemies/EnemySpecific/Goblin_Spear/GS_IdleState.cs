using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_IdleState : EnemyIdleState
{
    private Goblin_Spear goblin_spear;
    public GS_IdleState(Entity entity, EnemiesFiniteStateMachiene stateMachine, string animBoolName, D_EnemyIdleState stateData, Goblin_Spear goblin_spear) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.goblin_spear = goblin_spear;   
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

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(goblin_spear.detectedPlayerState);
        }
        else if(isIdleTimeOver)
        {
            stateMachine.ChangeState(goblin_spear.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
