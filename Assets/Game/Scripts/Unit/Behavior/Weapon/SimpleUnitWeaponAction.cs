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
        if (!unit.weaponService.reloader.IsLoaded())
            return;
        if (unit.unitObserverCollection.unitsInShootRange.enemies.Count == 0)
            return;
        var target = unit.unitObserverCollection.unitsInShootRange.enemies[
            Random.Range(0, unit.unitObserverCollection.unitsInShootRange.enemies.Count - 1)];
        unit.weaponService.Shoot(target);
    }
}
