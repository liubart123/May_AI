using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleUnitWeaponAction : UnitWeaponAction
{
    public SimpleUnitWeaponAction(Unit unit) : base(unit)
    {

    }

    public override void ImplementWeaponAction()
    {
        if (!unit.WeaponService.Reloader.IsLoaded())
            return;
        if (unit.UnitObserverCollection.unitsInShootRange.enemies.Count == 0)
            return;
        var target = unit.UnitObserverCollection.unitsInShootRange.enemies[
            Random.Range(0, unit.UnitObserverCollection.unitsInShootRange.enemies.Count - 1)];
        unit.WeaponService.Shoot(target);
    }
}
