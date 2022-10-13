using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChaseNearestEnemyUnitMovementAction : UnitMovementAction
{
    public ChaseNearestEnemyUnitMovementAction(Unit unit) : base(unit)
    {
    }

    public override void ImplementMovementAction()
    {
        if (unit.UnitObserverCollection.unitsInViewRange.enemies.Count == 0)
        {
            unit.MovementService.StopMoving();
            return;
        }

        Vector2 nearestEnemyDirection = Vector2.zero;
        float nearestEnemyDistance = float.MaxValue;
        foreach (var enemy in unit.UnitObserverCollection.unitsInViewRange.enemies)
        {
            float distance = (enemy.transform.position - unit.transform.position).magnitude;
            if (distance< nearestEnemyDistance)
            {
                nearestEnemyDirection = enemy.transform.position - unit.transform.position;
                nearestEnemyDistance = distance;
            }
        }

        nearestEnemyDirection = nearestEnemyDirection.normalized;
        unit.MovementService.SetMovementDirection(nearestEnemyDirection);
    }
}
