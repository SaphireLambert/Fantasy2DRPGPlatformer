using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttackState : EnemyAttackState
{
    protected D_MeleeAttackState stateData;

    protected AttackDetails attackDetails;

    public EnemyMeleeAttackState(Entity entity, EnemiesFiniteStateMachiene stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData) : base(entity, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        attackDetails.damageAmount = stateData.attackDamage;
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        

        Collider2D[] detectedObjectes = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.playerLayerMask);
        foreach (Collider2D collider in detectedObjectes)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();
            if (damageable != null)
                damageable.Damage(attackDetails.damageAmount);
        }
    }
}
