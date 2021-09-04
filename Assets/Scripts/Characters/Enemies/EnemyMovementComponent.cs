// Copyright (C) 2021, Galactic Whales. All rights reserved.

using UnityEngine;
using PathCreation;
using System;

[RequireComponent(typeof(PathFollowComponent))]
public class EnemyMovementComponent : CharacterMovementComponent
{
    private PathFollowComponent pathFollowComponent;
    [HideInInspector] public PathCreator positioningPath;
    [HideInInspector] public PathCreator divingPath;
    [HideInInspector] public Transform formationSpot;

    private MovementProperties movementProperties;

    protected override void Awake()
    {
        base.Awake();

        pathFollowComponent = GetComponent<PathFollowComponent>();

        movementProperties = new MovementProperties(speed, EndOfPathInstruction.Stop);
    }

    public void StartPositioning()
    {
        if (pathFollowComponent != null)
        {
            pathFollowComponent.SetPath(positioningPath, movementProperties);
            pathFollowComponent.StartPathMovement();
        }
        else
        {
            Debug.LogError("EnemyMovementComponent::StartPositioning: pathFollowComponent is invalid.");
        }
    }

    public void StartDiving()
    {
        if (pathFollowComponent != null)
        {
            pathFollowComponent.SetPath(divingPath, movementProperties); 
            pathFollowComponent.StartPathMovement();
        }
        else
        {
            Debug.LogError("EnemyMovementComponent::StartDiving: pathFollowComponent is invalid.");
        }
    }

    public override void Move()
    {
    }
}