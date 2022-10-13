using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Poi - Point of Interest
/// </summary>
public class MoveToPoiUnitMovementAction : UnitMovementAction
{
    public MoveToPoiUnitMovementAction(Unit unit) : base(unit)
    {
    }

    public override void ImplementMovementAction()
    {
        if (unit.UnitBehaviorController.pointOfInterest == null)
        {
            unit.MovementService.StopMoving();
            return;
        }
        Vector2 moveDirection = unit.UnitBehaviorController.pointOfInterest - (Vector2)unit.transform.position;
        unit.MovementService.SetMovementDirection(moveDirection);
    }
}
