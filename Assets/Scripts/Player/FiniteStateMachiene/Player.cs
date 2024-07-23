using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachiene StateMachiene {  get; private set; } //Reference to script
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }

    public Animator Animator { get; private set; } //Reference to players animator
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }

    public Vector2 CurrentVelcoity {  get; private set; } //Reference to RB velocity to save memory by not calling the RB.Velocity fuction multiple times each frame. 
    public int FacingDirection {  get; private set; }

    [SerializeField]
    private PlayerData playerData;

    private Vector2 workSpace;

    private void Awake()
    {
        StateMachiene = new PlayerStateMachiene();

        IdleState = new PlayerIdleState(this, StateMachiene, playerData, "Idle");
        MoveState = new PlayerMoveState(this, StateMachiene, playerData, "Move");
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

    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, CurrentVelcoity.y);
        RB.velocity = workSpace;
        CurrentVelcoity = workSpace;
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
