using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    [SerializeField]
    private PlayerData playerData;
    public PlayerStateMachiene StateMachiene {  get; private set; } 
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    #endregion

    #region Check Transforms
    [SerializeField]
    private Transform groundCheck;
    #endregion

    #region Components
    public Animator Animator { get; private set; } 
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    #endregion

    #region Other
    public Vector2 CurrentVelcoity {  get; private set; } //Reference to RB velocity to save memory by not calling the RB.Velocity fuction multiple times each frame. 
    public int FacingDirection {  get; private set; }

    private Vector2 workSpace;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachiene = new PlayerStateMachiene();

        IdleState = new PlayerIdleState(this, StateMachiene, playerData, "Idle");
        MoveState = new PlayerMoveState(this, StateMachiene, playerData, "Move");
        JumpState = new PlayerJumpState(this, StateMachiene, playerData, "In Air");
        InAirState = new PlayerInAirState(this, StateMachiene, playerData, "In Air");
        LandState = new PlayerLandState(this, StateMachiene, playerData, "Landed");
    }

    private void Start()
    {
        Animator = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();

        FacingDirection = 1;

        StateMachiene.Initialise(IdleState);
    }

    private void Update()
    {
        CurrentVelcoity = RB.velocity;
        StateMachiene.CurrentState.LogicUpdate();

    }
    private void FixedUpdate()
    {
        StateMachiene.CurrentState.PhysicsUpdate();
    
    }
    #endregion

    #region Set Functions
    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, CurrentVelcoity.y);
        RB.velocity = workSpace;
        CurrentVelcoity = workSpace;
    }
    public void SetVelocityY(float velocity)
    {
        workSpace.Set(CurrentVelcoity.x, velocity);
        RB.velocity = workSpace;
        CurrentVelcoity = workSpace;
    }
    #endregion

    #region Check Functions
    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    #endregion

    #region Other Functions
    private void AnimationTrigger() => StateMachiene.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachiene.CurrentState.AnimationFinishTrigger();

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    #endregion
}
