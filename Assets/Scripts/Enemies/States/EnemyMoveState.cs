using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class EnemyMoveState : EnemiesState
{
    private Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }
    private CollisionSenses collisionSenses;

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

        if (CollisionSenses)
        {
            isDetectingLedge = CollisionSenses.isOnLedgeBool;
            //Debug.Log("I am not on a ledge = " + isDetectingLedge);
            isDetectingWall = CollisionSenses.isHittingWallBool;
            //Debug.Log("I can see a wall = " + isDetectingWall);
        }
        isPlayerInMinAgroRange = entity.isPlayerInMinAgroRangeBool;
        //Debug.Log("I can see the player = " + isPlayerInMinAgroRange);
    }

    public override void Enter()
    {
        base.Enter();
        Movement?.SetVelocityX(stateData.MovementSpeed * Movement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Movement?.SetVelocityX(stateData.MovementSpeed * Movement.FacingDirection);    
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
