// Copyright (C) 2021, Galactic Whales. All rights reserved.

using UnityEngine;

public class PlayerMovementComponent : CharacterMovementComponent
{
    protected override void Update()
    {
        
    }

    protected void FixedUpdate()
    {
        if (movementEnabled)
        {
            Move();
        }
    }

    public override void Move()
    {
        
    }
}