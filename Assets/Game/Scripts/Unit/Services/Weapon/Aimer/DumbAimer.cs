using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbAimer : Aimer
{
    public override Vector3 CalculateAim(Unit target)
    {
        //return target.transform.position - WeaponService.transform.position;
        var aimResult = LinearAimCalculator.CalculateAim(
            transform.position,
            target.GetComponent<Rigidbody2D>(),
            WeaponService.shooter.ShootForce);
        if (aimResult.isAvailableForHitting == false)
            return target.transform.position - WeaponService.transform.position;
        return aimResult.aim;
    }
}
