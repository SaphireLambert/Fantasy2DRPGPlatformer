using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchingWall : PlayerState
{
    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }

    private Movement movement;
    private CollisionSenses collisionSenses;

    protected bool isGrounded;
    protected bool isOnWall;

    protected int xInput;
    public PlayerTouchingWall(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName) : base(player, stateMachiene, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.InputHandler.NormInputX;

        if (isGrounded)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if (!isOnWall || xInput != Movement.FacingDirection)
        {
            stateMachine.ChangeState(player.InAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = CollisionSenses.isGroundedBool;
        isOnWall = CollisionSenses.isHittingWallBool;
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }
}
