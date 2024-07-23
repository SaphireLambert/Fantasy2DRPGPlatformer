using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; } //the value for the movemnet input range -1 to 1

    public int NormInputX {  get; private set; } //Makes the x input either equal -1, 0, 1 (No Decimals)
    public int NormInputY { get; private set; } //Makes the y input either equal -1, 0, 1 (No Decimals)
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;  
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
    }
    public void OnJumpInput(InputAction.CallbackContext context) 
    {

    }

}
