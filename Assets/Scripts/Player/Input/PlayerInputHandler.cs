using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum CombatInputs
{
    primary, 
    secondary
}

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; } //the value for the movemnet input range -1 to 1

    public int NormInputX {  get; private set; } //Value for the x input that either equals -1, 0, 1 (No Decimals)
    public int NormInputY { get; private set; } //Value for the y input that either equals -1, 0, 1 (No Decimals)
    public bool JumpInput {  get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool[] AttackInputs { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.15f;

    private float jumpInputStartTime;

    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        int count = Enum.GetValues(typeof(CombatInputs)).Length;    
        AttackInputs = new bool[count];
    }



    private void Update()
    {
        CheckJumpInputHoldTime();
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.primary] = true;
        }
        if(context.canceled)
        {
            AttackInputs[(int)CombatInputs.primary] = false;
        }
    }
    public void OnSecondaryAttackInput(InputAction.CallbackContext context) 
    {
        if(context.started)
        {
            AttackInputs[(int)CombatInputs.secondary] = true;
        }
        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    } 
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;  
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
    }
    public void OnJumpInput(InputAction.CallbackContext context) 
    {
        if(context.started)
        {
            JumpInput = true;
            jumpInputStartTime = Time.time; 
            JumpInputStop = false;  
        }
        if(context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void UseJumpInput() => JumpInput = false;    

    private void CheckJumpInputHoldTime()
    {
        if(Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

}
