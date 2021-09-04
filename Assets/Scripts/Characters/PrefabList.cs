using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPrefabList", menuName = "Data/PrefabList", order = 0)]
public class PrefabList : ScriptableObject
{
    [SerializeField] private GameObject[] prefabs;

    public GameObject[] Prefabs => prefabs;
}