// Copyright (C) 2021, Galactic Whales. All rights reserved.

using UnityEngine;

public class Character : MonoBehaviour
{
    protected HealthComponent healthComponent;

    public HealthComponent Health => healthComponent;

    private void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
    }
}