using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemiesState
{
    protected D_EnemyMoveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinAgroRange;

    public EnemyMoveState(Entity entity, EnemiesFiniteStateMachiene stateMachine, string animBoolName, D_EnemyMoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isDetectingLedge = core.CollisionSenses.isOnLedgeBool;
        //Debug.Log("I am not on a ledge = " + isDetectingLedge);
        isDetectingWall = core.CollisionSenses.isHittingWallBool;
        //Debug.Log("I can see a wall = " + isDetectingWall);
        isPlayerInMinAgroRange = entity.isPlayerInMinAgroRangeBool;
        //Debug.Log("I can see the player = " + isPlayerInMinAgroRange);
    }

    public override void Enter()
    {
        base.Enter();
        core.Movement.SetVelocityX(stateData.MovementSpeed * core.Movement.FacingDirection);
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
    }
}
