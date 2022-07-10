using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWeaponService : WeaponService
{
    public override void Shoot(Unit target)
    {
        if (!reloader.IsLoaded())
            return;
        shooter.Shoot(aimer.CalculateAim(target));
        reloader.Unload();
    }
}
