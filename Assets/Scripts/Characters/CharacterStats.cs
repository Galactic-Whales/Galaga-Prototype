using UnityEngine;

public abstract class CharacterStats : ScriptableObject
{
    [SerializeField] protected float baseSpeed;
    [SerializeField] protected int baseLifes;

    public float BaseSpeed => baseSpeed;
    public int BaseLifes => baseLifes;
}