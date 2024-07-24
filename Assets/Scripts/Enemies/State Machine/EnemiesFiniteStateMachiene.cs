using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesFiniteStateMachiene
{
    public EnemiesState CurrentState { get; private set; }

    public void Initialise(EnemiesState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(EnemiesState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
