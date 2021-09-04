using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FormationController : MonoBehaviour, ISceneController
{
    private Dictionary<Transform, IFormationAssignable> formationSpots;

    public void Initialize()
    {
        formationSpots = new Dictionary<Transform, IFormationAssignable>();

        foreach (Transform child in transform)
        {
            if (child != null)
            {
                formationSpots.Add(child, null);
            }
        }
    }

    public void Execute()
    {

    }

    public void OnStageChanged(GameStage newStage)
    {

    }

    public void AssignSpotTo(IFormationAssignable formationAssignable)
    {
        if (formationAssignable != null)
        {
            Transform spotT = FindSpotFor(formationAssignable);

            if (spotT != null)
            {
                formationAssignable.OnFormationAssigned(spotT);
                formationSpots[spotT] = formationAssignable;
            }
        }
        else
        {
            Debug.LogError("FormationHandler::AssignSpotTo: Invalid formationAssignable.");
        }
    }

    private Transform FindSpotFor(IFormationAssignable formationAssignable)
    {
        if (formationAssignable != null)
        {
            float minDistance = float.MaxValue;

            Transform spotT = null;

            foreach (var pair in formationSpots)
            {
                if (pair.Value == null)
                {
                    float distance = Vector2.Distance(pair.Key.position, formationAssignable.GetPosition());

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        spotT = pair.Key;
                    }
                }
            }

            return spotT;
        }
        else
        {
            Debug.LogError("FormationHandler::AssignSpotTo: Invalid formationAssignable.");
        }

        Debug.LogError("FormationHandler::FindSpotFor: No spot found.");
        return null;
    }
}