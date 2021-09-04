using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract void OnEnter(FiniteStateMachine FSM);
    public abstract void Execute(FiniteStateMachine FSM);
    public abstract void OnExit(FiniteStateMachine FSM);
}