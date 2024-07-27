using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Spear : Entity
{
    public GS_IdleState idleState {  get; private set; }

    public GS_MoveState moveState { get; private set; }

    public GS_DetectedPlayer detectedPlayerState {  get; private set; }

    public GS_ChargeState chargeState { get; private set; }

    public GS_LookForPlayerState lookForPlayerState { get; private set; }

    public GS_AttackState attackState { get; private set; } 


    [SerializeField]
    private D_EnemyIdleState idleStateData;
    [SerializeField]
    private D_EnemyMoveState moveStateData;
    [SerializeField]
    private D_EnemyDetectPlayer detectPlayerStateData;
    [SerializeField]
    private D_EnemyChargeState chargeStateData;
    [SerializeField]
    private D_EnemyLookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttackState meleeAttackStateData;


    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Awake()
    {
        base.Awake();

        moveState = new GS_MoveState(this, stateMachiene, "Move", moveStateData, this);
        idleState = new GS_IdleState(this, stateMachiene, "Idle", idleStateData, this);
        detectedPlayerState = new GS_DetectedPlayer (this, stateMachiene, "Detected Player", detectPlayerStateData, this);
        chargeState = new GS_ChargeState(this, stateMachiene, "Charge", chargeStateData, this);
        lookForPlayerState = new GS_LookForPlayerState(this, stateMachiene, "Looking For Player", lookForPlayerStateData, this);
        attackState = new GS_AttackState(this, stateMachiene,"Attack", meleeAttackPosition, meleeAttackStateData, this);

        stateMachiene.Initialise(moveState);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}
