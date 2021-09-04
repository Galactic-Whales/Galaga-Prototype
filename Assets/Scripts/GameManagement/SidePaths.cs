using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

[CreateAssetMenu(fileName = "NewSidePaths", menuName = "Data/Enemies/SidePaths", order = 0)]
public class SidePaths : ScriptableObject
{
    [SerializeField] private SidePath[] sidePaths;

    public SidePath[] Paths => sidePaths;

    public PathCreator[] GetPathsFor(SpawnSide side)
    {
        foreach (SidePath sidePath in sidePaths)
        {
            if (sidePath != null && sidePath.Side == side)
            {
                return sidePath.Paths;
            }
        }

        Debug.LogError($"SidePaths::GetPathsFor: No paths found for {side.ToString()}.");
        return null;
    }
}

[System.Serializable]
public class SidePath
{
    [SerializeField] private SpawnSide side;
    [SerializeField] private PathCreator[] paths;

    public SpawnSide Side => side;
    public PathCreator[] Paths => paths;
}