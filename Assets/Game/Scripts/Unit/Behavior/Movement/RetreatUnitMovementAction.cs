using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RetreatUnitMovementAction : UnitMovementAction
{
    public RetreatUnitMovementAction(Unit unit) : base(unit)
    {
    }

    public override void ImplementMovementAction()
    {
        if (unit.UnitObserverCollection.unitsInShootRange.enemies.Count == 0)
        {
            unit.MovementService.StopMoving();
            return;
        }

        List<Vector2> enemiesPositions = new List<Vector2>();
        foreach (var enemy in unit.UnitObserverCollection.unitsInShootRange.enemies)
        {
            Vector2 enemyPosition = enemy.transform.position - unit.transform.position;
            float distance = enemyPosition.magnitude;
            enemyPosition.Normalize();
            enemyPosition = enemyPosition * Mathf.Lerp(1, 0, distance / unit.UnitObserverCollection.unitsInShootRange.GetRadius());
            enemiesPositions.Add(enemyPosition);
        }

        Vector2 retreatDirection = Vector2.zero;
        foreach(var pos in enemiesPositions)
        {
            retreatDirection += pos;
        }

        retreatDirection = retreatDirection.normalized * -1;
        unit.MovementService.SetMovementDirection(retreatDirection);
    }
}
