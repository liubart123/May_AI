using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemiesUnitMovementAction : UnitMovementAction
{
    public ChaseEnemiesUnitMovementAction(Unit unit) : base(unit)
    {
    }

    public override void ImplementMovementAction()
    {
        if (unit.UnitObserverCollection.unitsInViewRange.enemies.Count == 0)
        {
            unit.MovementService.StopMoving();
            return;
        }

        List<Vector2> enemiesPositions = new List<Vector2>();
        foreach (var enemy in unit.UnitObserverCollection.unitsInViewRange.enemies)
        {
            Vector2 enemyPosition = enemy.transform.position - unit.transform.position;
            float distance = enemyPosition.magnitude;
            enemyPosition.Normalize();
            enemyPosition = enemyPosition * Mathf.Lerp(1, 0, distance / unit.UnitObserverCollection.unitsInViewRange.GetRadius());
            enemiesPositions.Add(enemyPosition);
        }

        Vector2 resultedDirection = Vector2.zero;
        foreach (var pos in enemiesPositions)
        {
            resultedDirection += pos;
        }

        resultedDirection = resultedDirection.normalized;
        unit.MovementService.SetMovementDirection(resultedDirection);
    }
}
