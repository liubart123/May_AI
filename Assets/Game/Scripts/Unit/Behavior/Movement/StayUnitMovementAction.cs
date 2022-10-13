using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayUnitMovementAction : UnitMovementAction
{
    public StayUnitMovementAction(Unit unit) : base(unit)
    {
    }

    public override void ImplementMovementAction()
    {
        unit.MovementService.StopMoving();
    }
}
