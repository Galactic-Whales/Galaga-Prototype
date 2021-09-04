// Copyright (C) 2021, Galactic Whales. All rights reserved.

using UnityEngine;
using System;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int startingLifes = 1;
    [SerializeField] private int minLifes = 0;
    [SerializeField] private int maxLifes = 1;

    private int lifes = 0;

    public int Lifes => lifes;

    public event Action<int> OnHealthChange;

    private void Awake()
    {
        SetLifes(startingLifes);
    }

    public void ModifyLifes(int amount)
    {
        int newLifes = lifes + amount;
        SetLifes(newLifes);
    }

    public void SetLifes(int count)
    {
        lifes = count;
        lifes = Mathf.Clamp(lifes, minLifes, maxLifes);

        OnHealthChange?.Invoke(lifes);
    }
}