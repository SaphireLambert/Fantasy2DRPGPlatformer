using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_MoveState : EnemyMoveState
{
    private Goblin_Spear goblin_spear; //In the video he calls this enemy
    public GS_MoveState(Entity entity, EnemiesFiniteStateMachiene stateMachine, string animBoolName, D_EnemyMoveState stateData, Goblin_Spear goblin_spear) : base(entity, stateMachine, animBoolName, stateData)
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

        if (isDetectingWall || !isDetectingLedge)
        {
            goblin_spear.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(goblin_spear.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
