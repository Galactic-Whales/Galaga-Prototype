using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerStats", menuName = "Data/Player/PlayerStats")]
public sealed class PlayerStats : CharacterStats
{
    [Header("Shooting")]
    [SerializeField] private float shotsPerSecond;
    [SerializeField] private int availableShotsOnScreen;

    public float ShotsPerSecond => shotsPerSecond;
    public int AvailableShotsOnScreen => availableShotsOnScreen;
}