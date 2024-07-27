using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the class that allows the enemy to detect the player. 
/// This derives from the state class 
/// </summary>
public class EnemyDetectPlayerState : EnemiesState
{
    protected D_EnemyDetectPlayer stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool performLongRangeAction;
    protected bool performCloseRangeAction;

    public EnemyDetectPlayerState(Entity entity, EnemiesFiniteStateMachiene stateMachine, string animBoolName, D_EnemyDetectPlayer stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = entity.isPlayerInMinAgroRangeBool;
        isPlayerInMaxAgroRange = entity.isPlayerInMaxAgroRangeBool;
        performCloseRangeAction = entity.isPlayerInCloseRangeActionBool;
    }

    public override void Enter()
    {
        base.Enter();
        core.Movement.SetVelocityX(0);
        performLongRangeAction = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.Movement.SetVelocityX(0);

        if (Time.time >= startTime + stateData.longRangeActionTime)
        {
            performLongRangeAction = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
