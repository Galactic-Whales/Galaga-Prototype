// Copyright (C) 2021, Galactic Whales. All rights reserved.

using UnityEngine;

public class PlayerMovementComponent : CharacterMovementComponent
{
    private float HorizontalInput;

    protected override void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
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
        rb.velocity = new Vector2(HorizontalInput, 0) * speed;
    }
}