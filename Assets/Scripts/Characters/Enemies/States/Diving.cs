using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diving : State
{
    public override void OnEnter(FiniteStateMachine FSM)
    {

    }

    public override void Execute(FiniteStateMachine FSM)
    {
        Vector3 targetLocation = transform.position + Vector3.down * 10.0f * Time.deltaTime;
        transform.position = targetLocation;
    }

    public override void OnExit(FiniteStateMachine FSM)
    {

    }
}