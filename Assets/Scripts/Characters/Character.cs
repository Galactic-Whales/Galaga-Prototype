// Copyright (C) 2021, Galactic Whales. All rights reserved.

using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected CharacterStats characterStats;

    protected HealthComponent healthComponent;
    protected CharacterMovementComponent movementComponent;

    public HealthComponent Health => healthComponent;
    public CharacterMovementComponent MovementComponent => movementComponent;

    protected virtual void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        movementComponent = GetComponent<CharacterMovementComponent>();
    }

    private void Start()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        ICharacterComponent[] characterComponents = GetComponents<ICharacterComponent>();

        foreach (ICharacterComponent characterComponent in characterComponents)
        {
            if (characterComponent != null)
            {
                characterComponent.OnDataInitialized(characterStats);
            }
        }
    }
}