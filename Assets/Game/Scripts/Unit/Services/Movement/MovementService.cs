using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementService : MonoBehaviour
{
    protected Vector2 direction, targetPosition;
    protected enum EMovementTarget
    {
        direction, position
    }
    protected EMovementTarget movementTargetType;
    protected bool isMoving;

    public virtual void SetMovementPosition(Vector2 position)
    {
        movementTargetType = EMovementTarget.position;
        targetPosition = position;
        StartMoving();
    }
    public virtual void SetMovementDirection(Vector2 direction)
    {
        movementTargetType = EMovementTarget.direction;
        this.direction = direction;
        if (this.direction != Vector2.zero)
            StartMoving();
        else
            StopMoving();
    }
    public abstract void StopMoving();
    public abstract void StartMoving();
    public virtual bool IsMoving()
    {
        return isMoving;
    }
}
