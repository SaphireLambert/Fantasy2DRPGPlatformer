using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachiene
{
    public PlayerState CurrentState {  get; private set; } //Reference to script

    public void Initialise(PlayerState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

}
