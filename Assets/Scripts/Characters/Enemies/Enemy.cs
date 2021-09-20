using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System;

[RequireComponent(typeof(PathFollowComponent), typeof(FiniteStateMachine))]
public class Enemy : Character, IFormationAssignable
{
    [HideInInspector] public PathCreator positioningPath;
    [HideInInspector] public PathCreator divingPath;
    [HideInInspector] public Transform formationSpot;

    protected EnemyMovementComponent enemyMovementComponent;

    [SerializeField] private State defaultState;
    protected FiniteStateMachine FSM;

    protected override void Awake()
    {
        base.Awake();

        enemyMovementComponent = movementComponent as EnemyMovementComponent;
        FSM = GetComponent<FiniteStateMachine>();

        if (FSM != null)
        {
            FSM.SetNextState(defaultState);
        }
        else
        {
            //FiniteStateMachine component was not added to the GO.
            Debug.Break();
        }
    }

    private void Update()
    {
        if (FSM != null)
        {
            FSM.Execute();
        }
    }


    public void OnFormationAssigned(Transform spotT)
    {
        formationSpot = spotT;
    }

    public void OnFormationUnassigned()
    {

    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }
}