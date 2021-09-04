using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System;

public sealed class PathFollowComponent : MonoBehaviour
{
    private PathCreator pathToFollow;
    private float distanceTravelled;

    private bool canMove;

    private MovementProperties movementProperties;

    public event Action<PathCreator> OnPathMovementFinished;

    public void SetPath(PathCreator path, MovementProperties movementProperties)
    {
        if (path != null)
        {
            pathToFollow = path;
            this.movementProperties = movementProperties;
            canMove = false;
        }
    }

    public void StartPathMovement()
    {
        distanceTravelled = 0.0f;
        canMove = true;
    }

    public void EndPathMovement()
    {
        canMove = false;
        OnPathMovementFinished?.Invoke(pathToFollow);
        pathToFollow = null;
        movementProperties = default;
    }

    private void Update()
    {
        if (pathToFollow != null && canMove)
        {
            distanceTravelled += movementProperties.Speed * Time.deltaTime;
            transform.position = pathToFollow.path.GetPointAtDistance(distanceTravelled, movementProperties.PathEndInstruction);

            if (distanceTravelled >= pathToFollow.path.length)
            {
                EndPathMovement();
            }
        }
    }
}

public struct MovementProperties
{
    public MovementProperties(float speed, EndOfPathInstruction instuction)
    {
        Speed = speed;
        PathEndInstruction = instuction;
    }

    public readonly float Speed;
    public readonly EndOfPathInstruction PathEndInstruction;
}