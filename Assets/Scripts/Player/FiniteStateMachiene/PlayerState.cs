using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Core core;

    protected Player player;  //Reference to script
    protected PlayerStateMachiene stateMachiene;  //Reference to script
    protected PlayerData playerData;  //Reference to script

    protected bool isAnimationFinished;

    protected float startTime; //The starting time for the state/animation

    private string animBoolName;  //The name for the animation bool in the animation controller

    public PlayerState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachiene = stateMachiene;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
        core = player.Core;
    }

    public virtual void Enter() //Function for entering the state
    {
        DoChecks();
        player.Animator.SetBool(animBoolName, true);
        startTime = Time.time;
        isAnimationFinished = false;
    }

    public virtual void Exit() //Function for exiting the state
    {
        player.Animator.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate() //Fuction that acts as unitys Update - Updates the state every frame
    { 
    
    }

    public virtual void PhysicsUpdate() //Function that acts as Unity's Fixed Update
    {
        DoChecks();
    }

    public virtual void DoChecks() //Function that handles different checks for example: (IsGrounded?)
    {

    }

    public virtual void AnimationTrigger()
    {

    }

    public virtual void AnimationFinishTrigger()
    {
        isAnimationFinished = true;
    }
}
