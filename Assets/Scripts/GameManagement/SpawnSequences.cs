using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnSequence", menuName = "Data/Enemies/SpawnSequences", order = 1)]
public class SpawnSequences : ScriptableObject
{
    [SerializeField] private SpawnSequence[] sequences;
    
    public SpawnSequence[] Sequences => sequences;

    public SpawnSequence GetSequence(GameStage stage)
    {
        foreach (SpawnSequence sequence in sequences)
        {
            if (sequence != null)
            {
                if (sequence.Stage == stage)
                {
                    return sequence;
                }
            }
        }

        Debug.LogError($"SpawnSequences::GetSequence: Sequence not found for {stage.ToString()}");
        return null;
    }
}

[System.Serializable]
public sealed class SpawnSequence
{
    [SerializeField] private GameStage stage;
    [SerializeField] private SpawnSide[] sequence;

    public GameStage Stage => stage;
    public SpawnSide[] Sequence => sequence;
}