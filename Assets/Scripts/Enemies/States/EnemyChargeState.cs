using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class EnemyChargeState : EnemiesState
{
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
        isDetectingLedge = core.CollisionSenses.isOnLedgeBool;
        isDetectingWall = core.CollisionSenses.isHittingWallBool;
        performCloseRangeAction = entity.isPlayerInCloseRangeActionBool;
    }

    public override void Enter()
    {
        base.Enter();

        core.Movement.SetVelocityX(stateData.chargeSpeed * core.Movement.FacingDirection);
        isChargeTimeOver = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        core.Movement.SetVelocityX(stateData.chargeSpeed * core.Movement.FacingDirection);
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
