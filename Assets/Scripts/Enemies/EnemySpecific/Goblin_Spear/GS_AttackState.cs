using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_AttackState : EnemyMeleeAttackState
{
    private Goblin_Spear goblin_Spear;

    public GS_AttackState(Entity entity, EnemiesFiniteStateMachiene stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData, Goblin_Spear goblin_Spear) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isAnimationFinished)
        {
            if(isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(goblin_Spear.detectedPlayerState);
            }
            else
            {
                stateMachine.ChangeState(goblin_Spear.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
