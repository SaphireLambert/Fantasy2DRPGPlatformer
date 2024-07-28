using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xinput;

    protected Movement Movement { get=> movement??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); } 
    private CollisionSenses collisionSenses;

    private bool jumpInput;
    private bool isGrounded;
    public PlayerGroundedState(Player player, PlayerStateMachiene stateMachiene, PlayerData playerData, string animBoolName) : base(player, stateMachiene, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        if ((CollisionSenses))
        {
            isGrounded = CollisionSenses.isGroundedBool;
        }
    }

    public override void Enter()
    {
        base.Enter();
        player.JumpState.RestAmountOfJumps();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xinput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;

        if (player.InputHandler.AttackInputs[(int)CombatInputs.primary])
        {
            stateMachiene.ChangeState(player.PrimaryAttackState);
        }
        else if (player.InputHandler.AttackInputs[(int)CombatInputs.secondary])
        {
            stateMachiene.ChangeState(player.SecondAttackState);
        }
        else if(jumpInput && player.JumpState.CanJump())
        {
            player.InputHandler.UseJumpInput();
            stateMachiene.ChangeState(player.JumpState);
        }
        else if(!isGrounded)
        {
            player.InAirState.StartCoyoteTime();
            stateMachiene.ChangeState(player.InAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
