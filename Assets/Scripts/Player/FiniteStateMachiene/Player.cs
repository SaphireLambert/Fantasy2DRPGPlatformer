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
    public PlayerAttackState PrimaryAttackState { get; private set; }
    public PlayerAttackState SecondAttackState { get;private set; }
    #endregion

    #region Components
    public Animator Animator { get; private set; } 
    public PlayerInputHandler InputHandler { get; private set; }
    public PlayerInventory Inventory { get; private set; }
    public Core Core { get; private set; }
    #endregion

    #region Other
    public Vector2 CurrentVelcoity {  get; private set; } //Reference to RB velocity to save memory by not calling the RB.Velocity fuction multiple times each frame. 

    private Vector2 workSpace;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();

        StateMachiene = new PlayerStateMachiene();

        IdleState = new PlayerIdleState(this, StateMachiene, playerData, "Idle");
        MoveState = new PlayerMoveState(this, StateMachiene, playerData, "Move");
        JumpState = new PlayerJumpState(this, StateMachiene, playerData, "In Air");
        InAirState = new PlayerInAirState(this, StateMachiene, playerData, "In Air");
        LandState = new PlayerLandState(this, StateMachiene, playerData, "Landed");

        PrimaryAttackState = new PlayerAttackState(this, StateMachiene, playerData, "Attack");
        SecondAttackState = new PlayerAttackState(this, StateMachiene, playerData, "Attack");
    }

    private void Start()
    {
        Animator = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Inventory = GetComponent<PlayerInventory>();

        PrimaryAttackState.SetWeapon(Inventory.weapons[(int)CombatInputs.primary]);
        //SecondAttackState.SetWeapon(Inventory.weapons[(int)CombatInputs.secondary]);

        StateMachiene.Initialise(IdleState);
    }

    private void Update()
    {
        Core.LogicUpdate();
        StateMachiene.CurrentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        StateMachiene.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Other Functions
    private void AnimationTrigger() => StateMachiene.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachiene.CurrentState.AnimationFinishTrigger();
    #endregion
}
