using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleUnitDecisionMaker : UnitDecisionMaker
{
    public UnitMovementAction movementAction;
    public UnitWeaponAction weaponAction;

    #region movement actions
    ChaseEnemiesUnitMovementAction chaseEnemiesUnitMovementAction;
    ChaseNearestEnemyUnitMovementAction chaseNearestEnemyUnitMovementAction;
    MoveToPoiUnitMovementAction moveMoveToPoiUnitMovementAction;
    RetreatUnitMovementAction retreatUnitMovementAction;
    StayUnitMovementAction stayUnitMovementAction;
    #endregion

    public override UnitMovementAction ChooseMovementAction()
    {
        return retreatUnitMovementAction;
        return stayUnitMovementAction;
        return chaseEnemiesUnitMovementAction;
        return chaseNearestEnemyUnitMovementAction;
    }

    public override UnitWeaponAction ChooseWeaponAction()
    {
        if (weaponAction is SimpleUnitWeaponAction == false)
            weaponAction = new SimpleUnitWeaponAction(Owner);
        return weaponAction;
    }

    public override void Initialize()
    {
        chaseEnemiesUnitMovementAction = new ChaseEnemiesUnitMovementAction(Owner);
        chaseNearestEnemyUnitMovementAction = new ChaseNearestEnemyUnitMovementAction(Owner);
        movementAction = new MoveToPoiUnitMovementAction(Owner);
        retreatUnitMovementAction = new RetreatUnitMovementAction(Owner);
        stayUnitMovementAction = new StayUnitMovementAction(Owner);
    }
}
