using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public sealed class GameManager : MonoBehaviour
{
    private ISceneController[] controllers;
    private GameStage currentStage;

    public GameStage CurrentStage => currentStage;

    private void Awake()
    {
        controllers = GetComponentsInChildren<ISceneController>();
    }

    private void Start()
    {
        HandleController<ISceneController>((controller) => { controller.Initialize(); });

        HandleController<EnemySpawnController>((controller) => { controller.OnEnemySpawned += OnEnemySpawned; });

        SetNewStage(GameStage.Stage1);
    }

    private void Update()
    {
        HandleController<ISceneController>((controller) => { controller.Execute(); });
    }

    private void SetNewStage(GameStage newStage)
    {
        currentStage = newStage;
        HandleController<ISceneController>((controller) => { controller.OnStageChanged(newStage); });
    }

    private void HandleController<T>(Action<T> action) where T : ISceneController
    {
        foreach (ISceneController controller in controllers)
        {
            if (controller is T specificController)
            {
                action?.Invoke(specificController);
            }
            else if (controller == null)
            {
                Debug.LogError("GameManager::HandleController: Controller is invalid.");
            }
        }
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        HandleController<FormationController>((controller) => { controller.AssignSpotTo(enemy); });
    }
}