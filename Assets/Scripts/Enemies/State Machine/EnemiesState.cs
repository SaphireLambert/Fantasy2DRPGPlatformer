using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesState
{
    protected EnemiesFiniteStateMachiene stateMachine;
    protected Entity entity;
    protected Core core;

    protected float startTime;

    protected string animBoolName;

    public EnemiesState(Entity entity, EnemiesFiniteStateMachiene stateMachine, string animBoolName)
    {
        this.stateMachine = stateMachine;
        this.entity = entity;
        this.animBoolName = animBoolName;
        core = entity.Core;  
    }
    public virtual void DoChecks()
    {

    }
    public virtual void Enter()
    {
        startTime = Time.time;
        entity.Animator.SetBool(animBoolName, true);
        DoChecks();
    }

    public virtual void Exit() 
    {
        entity.Animator.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }
}
