using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public sealed class Positioning : State, ICharacterComponent
{
    private Enemy enemy;
    private PathFollowComponent pathFollowComponent;
    private InFormation inFormationState;

    private float speed;

    private Vector2 startLocation;
    private Vector2 endLocation;

    private bool shouldMoveToFormation;

    private float distanceTravelled;
    private float startToEndDistance;

    private PathMovementProperties movementProperties;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();    
        pathFollowComponent = GetComponent<PathFollowComponent>();
        inFormationState = GetComponent<InFormation>();

    }

    public void OnDataInitialized(CharacterStats characterStats)
    {
        if (characterStats != null)
        {
            speed = characterStats.BaseSpeed;

            movementProperties = new PathMovementProperties(speed, EndOfPathInstruction.Stop);
        }
    }

    public override void OnEnter(FiniteStateMachine FSM)
    {
        ResetValues();

        if (enemy != null)
        {
            transform.position = enemy.positioningPath.bezierPath.GetPoint(0);
        }

        StartCoroutine(StartMovementDelay());
    }

    public override void Execute(FiniteStateMachine FSM)
    {
        if (shouldMoveToFormation)
        {
            distanceTravelled += Time.deltaTime * speed;
            transform.position = Vector2.Lerp(startLocation, endLocation, distanceTravelled / startToEndDistance);

            if (distanceTravelled >= 1.0f && FSM != null)
            {
                FSM.SetNextState(inFormationState);
            }
        }
    }

    public override void OnExit(FiniteStateMachine FSM)
    {
        ResetValues();
    }

    private void OnPathFinished(PathCreator path)
    {
        if (pathFollowComponent != null)
        {
            pathFollowComponent.OnPathMovementFinished -= OnPathFinished;
        }

        if (enemy != null)
        {
            startLocation = transform.position;
            endLocation = enemy.formationSpot.position;
            startToEndDistance = Vector2.Distance(startLocation, endLocation);
            distanceTravelled = 0.0f;
            
            shouldMoveToFormation = true;
        }
    }

    private void ResetValues()
    {
        startLocation = Vector2.zero;
        endLocation = Vector2.zero;
        startToEndDistance = 0.0f;
        distanceTravelled = 0.0f;

        shouldMoveToFormation = false;
    }

    private IEnumerator StartMovementDelay()
    {
        yield return new WaitForSeconds(enemy ? enemy.positioningDelay : 0.0f);

        if (pathFollowComponent != null)
        {
            pathFollowComponent.OnPathMovementFinished += OnPathFinished;

            pathFollowComponent.SetPath(enemy.positioningPath, movementProperties);
            pathFollowComponent.StartPathMovement();
        }
        else
        {
            Debug.LogError("EnemyMovementComponent::StartPositioning: pathFollowComponent is invalid.");
        }
    }
}