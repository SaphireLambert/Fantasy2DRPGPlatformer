using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemiesState
{
    protected Transform attackPosition;

    protected bool isAnimationFinished;
    protected bool isPlayerInMinAgroRange;

    public EnemyAttackState(Entity entity, EnemiesFiniteStateMachiene stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = entity.isPlayerInMinAgroRangeBool;
    }

    public override void Enter()
    {
        base.Enter();

        entity.animationToStateMachine.attackState = this;
        isAnimationFinished = false;
        core.Movement.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        core.Movement.SetVelocityX(0f);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void TriggerAttack()
    {

    }

    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}
