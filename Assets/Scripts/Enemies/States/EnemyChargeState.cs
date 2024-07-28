using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class EnemyChargeState : EnemiesState
{
    private Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }

    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }

    private Movement movement;
    private CollisionSenses collisionSenses;

    protected D_EnemyChargeState stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;
    protected bool isChargeTimeOver;
    protected bool performCloseRangeAction;
    public EnemyChargeState(Entity entity, EnemiesFiniteStateMachiene stateMachine, string animBoolName, D_EnemyChargeState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = entity.isPlayerInMinAgroRangeBool;
        performCloseRangeAction = entity.isPlayerInCloseRangeActionBool;

        if (CollisionSenses)
        {
            isDetectingLedge = CollisionSenses.isOnLedgeBool;
            isDetectingWall = CollisionSenses.isHittingWallBool;
        }
        
    }

    public override void Enter()
    {
        base.Enter();

        Movement?.SetVelocityX(stateData.chargeSpeed * Movement.FacingDirection);
        isChargeTimeOver = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Movement?.SetVelocityX(stateData.chargeSpeed * Movement.FacingDirection);
        if (Time.time >= startTime + stateData.chargeTime)
        {
            isChargeTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
