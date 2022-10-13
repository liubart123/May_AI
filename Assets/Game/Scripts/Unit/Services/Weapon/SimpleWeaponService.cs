using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWeaponService : WeaponService
{
    public override void Shoot(Unit target)
    {
        if (!Reloader.IsLoaded())
            return;

        //TODO: change to use shotRangeObserver
        if ((target.transform.position - Owner.transform.position).magnitude > shootRange)
            return;

        Shooter.Shoot(Aimer.CalculateAim(target));
        Reloader.Unload();
    }
}
