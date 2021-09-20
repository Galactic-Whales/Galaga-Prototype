using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System;

public sealed class EnemySpawnController : MonoBehaviour, ISceneController
{
    [SerializeField] private PrefabList enemyPrefabs;

    [SerializeField] private SpawnSequences spawnSequences;
    [SerializeField] private SidePaths sidePaths;

    private GameObject[] possibleEnemies;

    private SpawnSide[] currentSpawnSequence;
    private int currentPathIndex;

    public event Action<Enemy> OnEnemySpawned;

    public void Initialize()
    {
        if (enemyPrefabs != null)
        {
            possibleEnemies = enemyPrefabs.Prefabs;
        }
    }

    public void OnStageChanged(GameStage newStage)
    {
        ResetPaths();
        UpdateCurrentSequence(newStage);
        SpawnEnemy(possibleEnemies[0]);

        switch (newStage)
        {
            case GameStage.Stage1:
                break;
            case GameStage.Stage2:
                break;
            case GameStage.Stage3:
                break;
            case GameStage.ChallengeStage:
                break;
            default:
                break;
        }
    }

    public void Execute()
    {
        
    }

    private void UpdateCurrentSequence(GameStage currentStage)
    {
        if (spawnSequences != null)
        {
            SpawnSequence sequence = spawnSequences.GetSequence(currentStage);

            if (sequence != null)
            {
                currentSpawnSequence = sequence.Sequence;
            }
            else
            {
                Debug.LogError("EnemySpawnController::UpdateCurrentSequence: Sequence is invalid.");
            }
        }
    }

    private void ResetPaths()
    {
        currentPathIndex = 0;
        currentSpawnSequence = null;
    }

    public void SpawnEnemy(GameObject enemyPrefab)
    {
        if (enemyPrefab != null)
        {
            if (currentSpawnSequence.Length > 0)
            {
                GameObject enemyInstance = Instantiate(enemyPrefab);

                if (enemyInstance != null)
                {
                    Enemy enemy = enemyInstance.GetComponent<Enemy>();

                    if (enemy != null)
                    {
                        PathCreator pathPrefab = SelectPath();
                        GameObject pathInstance = Instantiate(pathPrefab.gameObject);

                        enemy.positioningPath = pathInstance.GetComponent<PathCreator>();

                        OnEnemySpawned?.Invoke(enemyInstance.GetComponent<Enemy>());
                    }
                }
            }
            else
            {
                Debug.LogError("EnemySpawnController::SpawnEnemy: Invalid sequence.");
            }
        }
        else
        {
            Debug.LogError("EnemySpawnController::SpawnEnemy: Invalid reference.");
        }
    }

    private PathCreator SelectPath()
    {
        if (currentSpawnSequence != null && sidePaths != null)
        {
            SpawnSide spawnSide = currentSpawnSequence[currentPathIndex];
            PathCreator[] paths = sidePaths.GetPathsFor(spawnSide);

            if (paths.Length > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, paths.Length - 1);

                return paths[randomIndex];
            }

            Debug.LogError("EnemySpawnController::SelectPath: No path found.");
        }
        else
        {
            Debug.LogError("EnemySpawnController::SelectPath: Invalid references.");
        }
        
        return null;
    }
}