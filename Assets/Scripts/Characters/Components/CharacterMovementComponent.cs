// Copyright (C) 2021, Galactic Whales. All rights reserved.

using UnityEngine;

public abstract class CharacterMovementComponent : MonoBehaviour
{
    public float speed;
    public bool movementEnabled = true;

    public abstract void Move();

    protected virtual void Update()
    {
        if (movementEnabled)
        {
            Move();
        }
    }
}