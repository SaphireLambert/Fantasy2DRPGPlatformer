using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public EnemiesFiniteStateMachiene stateMachiene;

    public Animator Animator { get; private set; }

    public Core Core { get; private set; }

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
        Animator = GetComponent<Animator>();

        stateMachiene = new EnemiesFiniteStateMachiene();
    }

    public virtual void Update()
    {
        stateMachiene.CurrentState.LogicUpdate();

        Animator.SetFloat("YVelocity", Core.Movement.RB.velocity.y);
    }
    public virtual void FixedUpdate()
    {
        stateMachiene.CurrentState.PhysicsUpdate();
    }

}
