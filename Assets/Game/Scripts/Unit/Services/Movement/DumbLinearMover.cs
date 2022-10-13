using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbLinearMover : MovementService
{
    [Range(0.1f,1)]
    public float minDistanceToTargetPosition;
    Rigidbody2D Rigidbody
    {
        get
        {
            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody2D>();
            }
            return _rigidbody;
        }
    }
    Rigidbody2D _rigidbody;
    public float speed;

    private void Start()
    {
        StartCoroutine(MovePeriodically());
        StartCoroutine(StopIfAchieveDestinationPeriodically());
    }

    IEnumerator MovePeriodically()
    {
        while (true)
        {
            if (isMoving)
            {
                SetRbVelocity();
            }
            if (isMoving &&
                movementTargetType == EMovementTarget.position)
            {
                StopIfAchieveDestination();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator StopIfAchieveDestinationPeriodically()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
        }
    }
    void StopIfAchieveDestination()
    {
        float difference = (new Vector2(
            targetPosition.x - transform.position.x,
            targetPosition.y - transform.position.y)).magnitude;
        if (difference < minDistanceToTargetPosition)
        {
            StopMoving();
        }
    }

    public override void StopMoving()
    {
        isMoving = false;
        Rigidbody.velocity = Vector3.zero;
    }

    public override void StartMoving()
    {
        isMoving = true;
        SetRbVelocity();
        StopIfAchieveDestination();
    }

    void SetRbVelocity()
    {
        if (movementTargetType == EMovementTarget.direction)
        {
            Rigidbody.velocity = direction * speed;
        }
        else
        {
            Vector2 localDirection = new Vector2(
                 targetPosition.x - transform.position.x,
                 targetPosition.y - transform.position.y);

            Rigidbody.velocity = localDirection.normalized * speed;
        }
    }
}
