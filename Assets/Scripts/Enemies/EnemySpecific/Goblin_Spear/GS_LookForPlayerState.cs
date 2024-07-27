using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_LookForPlayerState : EnemyLookForPlayerState
{
    private Goblin_Spear goblin_Spear;
    public GS_LookForPlayerState(Entity entity, EnemiesFiniteStateMachiene stateMachine, string animBoolName, D_EnemyLookForPlayer stateData, Goblin_Spear goblin_Spear) : base(entity, stateMachine, animBoolName, stateData)
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
        if(isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(goblin_Spear.detectedPlayerState);
        }
        else if(isAllTurnsDone)
        {
            stateMachine.ChangeState(goblin_Spear.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
