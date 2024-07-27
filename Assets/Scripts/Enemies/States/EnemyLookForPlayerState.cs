using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookForPlayerState : EnemiesState
{
    protected D_EnemyLookForPlayer stateData;

    protected bool turnImmediatley;
    protected bool isPlayerInMinAgroRange;
    protected bool isAllTurnsDone; //Checks how many turns the enemy has made and returns true if all have been made.
    protected bool isAllTurnsTimeDone; //Does the same as aboive but instead of tracking the turns themsleves traks the time it takes before the enemies decid to turn again. 

    protected float lastTurnTime;

    protected int amountOfTurnsDone;

    public EnemyLookForPlayerState(Entity entity, EnemiesFiniteStateMachiene stateMachine, string animBoolName, D_EnemyLookForPlayer stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAgroRange = entity.isPlayerInMinAgroRangeBool;
    }

    public override void Enter()
    {
        base.Enter();

        isAllTurnsDone = false;
        isAllTurnsTimeDone = false;

        lastTurnTime = startTime;
        amountOfTurnsDone = 0;

        core.Movement.SetVelocityX(0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.Movement.SetVelocityX(0);

        if (turnImmediatley)
        {
            core.Movement.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
            turnImmediatley = false;
        }
        else if(Time.time >= lastTurnTime + stateData.timeBetweenTurns && !isAllTurnsDone)
        {
            core.Movement.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
        }

        if(amountOfTurnsDone >= stateData.amountOfTurns)
        {
            isAllTurnsDone = true;
        }

        if(Time.time >= lastTurnTime + stateData.timeBetweenTurns && isAllTurnsDone)
        {
            isAllTurnsDone = true;
        }
    }

public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public void SetTurnImmeduately(bool flip)
    {
        turnImmediatley = flip;
    }
}
