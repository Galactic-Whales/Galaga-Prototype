// Copyright (C) 2021, Galactic Whales. All rights reserved.

using UnityEngine;

public class Character : MonoBehaviour
{
    protected HealthComponent healthComponent;
    protected CharacterMovementComponent movementComponent;

    public HealthComponent Health => healthComponent;
    public CharacterMovementComponent MovementComponent => movementComponent;

    private void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        movementComponent = GetComponent<CharacterMovementComponent>();
    }
}