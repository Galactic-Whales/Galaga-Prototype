using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InFormation : State
{
    private Diving divingState;



    private void Awake()
    {
        divingState = GetComponent<Diving>();
    }

    public override void OnEnter(FiniteStateMachine FSM)
    {
        StartCoroutine(DivingDelay(FSM));
    }

    public override void Execute(FiniteStateMachine FSM)
    {

    }

    public override void OnExit(FiniteStateMachine FSM)
    {

    }

    private IEnumerator DivingDelay(FiniteStateMachine FSM)
    {
        yield return new WaitForSeconds(3.0f);

        if (FSM != null)
        {
            FSM.SetNextState(divingState);
        }
    }
}