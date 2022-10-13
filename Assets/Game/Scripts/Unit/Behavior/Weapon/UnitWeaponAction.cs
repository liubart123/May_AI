using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unit's action with weapon.
/// Defines target choosing strategy and shooting strategy
/// </summary>
public abstract class UnitWeaponAction
{
    public Unit unit;
    public UnitWeaponAction(Unit unit)
    {
        this.unit = unit;
    }
    public abstract void ImplementWeaponAction();
}
