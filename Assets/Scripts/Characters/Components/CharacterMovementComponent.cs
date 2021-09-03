// Copyright (C) 2021, Galactic Whales. All rights reserved.

using UnityEngine;

public abstract class CharacterMovementComponent : MonoBehaviour
{
    public float speed;
    public bool movementEnabled = true;

    protected Rigidbody2D rb;

    public abstract void Move();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        if (movementEnabled)
        {
            Move();
        }
    }
}