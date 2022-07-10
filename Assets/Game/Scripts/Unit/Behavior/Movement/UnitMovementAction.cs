using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitMovementAction 
{
    public Unit unit;
    public UnitMovementAction(Unit unit)
    {
        this.unit = unit;
    }
    public abstract void ImplementMovementAction();
}
