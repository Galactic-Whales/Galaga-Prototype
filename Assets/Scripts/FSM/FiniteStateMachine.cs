using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    private State currentState;
    private State nextState;
    public void SetNextState(State nextState)
    {
        this.nextState = nextState;
    }

    public void Execute()
    {
        if (nextState != null)
        {
            if (currentState != null)
            {
                currentState.OnExit(this);
            }

            currentState = nextState;
            nextState = null;

            currentState.OnEnter(this);
        }

        if (currentState != null)
        {
            currentState.Execute(this);
        }
    }
}