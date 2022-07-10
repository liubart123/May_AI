using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitWeaponAction
{
    public Unit unit;
    public UnitWeaponAction(Unit unit)
    {
        this.unit = unit;
    }
    public abstract void ImplementWeaponAction();
}
