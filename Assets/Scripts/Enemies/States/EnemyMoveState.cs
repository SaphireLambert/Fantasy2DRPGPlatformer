using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemiesState
{
    protected D_EnemyMoveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    public EnemyMoveState(Entity entity, EnemiesFiniteStateMachiene stateMachine, string animBoolName, D_EnemyMoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        core.Movement.SetVelocityX(stateData.MovementSpeed * core.Movement.FacingDirection);

        isDetectingLedge = core.CollisionSenses.isOnLedgeProperty;
        Debug.Log("Is on ledge is set to " + isDetectingLedge);

        isDetectingWall = core.CollisionSenses.isHittingWallProperty;
        Debug.Log("Is Touching wall is set to" + isDetectingWall);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        core.Movement.SetVelocityX(stateData.MovementSpeed * core.Movement.FacingDirection);    
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        isDetectingLedge = core.CollisionSenses.isOnLedgeProperty;
        isDetectingWall = core.CollisionSenses.isHittingWallProperty;
    }
}
