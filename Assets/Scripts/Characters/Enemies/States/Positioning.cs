using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public sealed class Positioning : State
{
    private EnemyMovementComponent movementComponent;
    private PathFollowComponent pathFollowComponent;
    private InFormation inFormationState;

    private Vector2 startLocation;
    private Vector2 endLocation;

    private bool shouldMoveToFormation;

    private float distanceTravelled;
    private float startToEndDistance;

    private void Awake()
    {
        movementComponent = GetComponent<EnemyMovementComponent>();    
        pathFollowComponent = GetComponent<PathFollowComponent>();
        inFormationState = GetComponent<InFormation>();
    }

    public override void OnEnter(FiniteStateMachine FSM)
    {
        if (movementComponent != null)
        {
            movementComponent.StartPositioning();
        }

        if (pathFollowComponent != null)
        {
            pathFollowComponent.OnPathMovementFinished += OnPathFinished;
        }
    }

    public override void Execute(FiniteStateMachine FSM)
    {
        if (shouldMoveToFormation)
        {
            distanceTravelled += Time.deltaTime * movementComponent.speed;
            transform.position = Vector2.Lerp(startLocation, endLocation, distanceTravelled / startToEndDistance);

            if (distanceTravelled >= 1.0f && FSM != null)
            {
                FSM.SetNextState(inFormationState);
            }
        }
    }

    public override void OnExit(FiniteStateMachine FSM)
    {

    }

    private void OnPathFinished(PathCreator path)
    {
        if (movementComponent != null && movementComponent.formationSpot != null)
        {
            startLocation = transform.position;
            endLocation = movementComponent.formationSpot.position;
            shouldMoveToFormation = true;
            startToEndDistance = Vector2.Distance(startLocation, endLocation);
        }
    }
}