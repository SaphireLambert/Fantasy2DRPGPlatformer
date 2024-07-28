using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Entity : MonoBehaviour
{
    protected Movement Movement { get => movement ??= Core.GetCoreComponent<Movement>(); }
    private Movement movement;

    public EnemiesFiniteStateMachiene stateMachiene;

    public D_Entity entityData;

    public Animator Animator { get; private set; }

    public Core Core { get; private set; }

    public AnimationToStateMachine animationToStateMachine {  get; private set; }

    [SerializeField]
    private Transform playerCheck; //This is reference to the game objecct creating the starting point for the raycast to find the player

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
        Animator = GetComponent<Animator>();
        animationToStateMachine = GetComponent<AnimationToStateMachine>();

        stateMachiene = new EnemiesFiniteStateMachiene();
    }

    public virtual void Update()
    {
        stateMachiene.CurrentState.LogicUpdate();

        Animator.SetFloat("YVelocity", Movement.RB.velocity.y);
    }
    public virtual void FixedUpdate()
    {
        stateMachiene.CurrentState.PhysicsUpdate();
    }

    /// <summary>
    /// These bools send a raycast to check in the player is within a distance to the enemy.
    /// This acts as the enemies sight lines (NOTE: This doesnt necessarily mean the enemy will attack in this range just see the player).
    /// </summary>
    public virtual bool isPlayerInMinAgroRangeBool 
    {
        get=> Physics2D.Raycast(playerCheck.position, transform.right, entityData.minAgroDistance, entityData.playerLayerMask);
    }
    public virtual bool isPlayerInMaxAgroRangeBool
    {
        get=> Physics2D.Raycast(playerCheck.position, transform.right, entityData.maxAgroDistance, entityData.playerLayerMask);
    }
    public virtual bool isPlayerInCloseRangeActionBool
    {
        get => Physics2D.Raycast(playerCheck.position, transform.right, entityData.closeRangeActionDistance, entityData.playerLayerMask);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawLine(transform.position, playerCheck.position + (Vector3)(Vector2.right * entityData.maxAgroDistance * Core.Movement.FacingDirection));
    //}

}
