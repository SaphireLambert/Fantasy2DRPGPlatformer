using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Spear : Entity
{
    public GS_IdleState idleState {  get; private set; }
    public GS_MoveState moveState { get; private set; }

    [SerializeField]
    private D_EnemyIdleState idleStateData;
    [SerializeField]
    private D_EnemyMoveState moveStateData;

    public override void Awake()
    {
        base.Awake();

        moveState = new GS_MoveState(this, stateMachiene, "Move", moveStateData, this);
        idleState = new GS_IdleState(this, stateMachiene, "Idle", idleStateData, this);

        stateMachiene.Initialise(moveState);
    }
}
