using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Aimer : MonoBehaviour
{
    protected WeaponService _weaponService;
    protected WeaponService WeaponService
    {
        get
        {
            if (_weaponService == null)
            {
                _weaponService = GetComponent<WeaponService>();
            }
            return _weaponService;
        }
    }

    protected Unit _unit;
    protected Unit Unit
    {
        get
        {
            if (_weaponService == null)
            {
                _unit = GetComponent<Unit>();
            }
            return _unit;
        }
    }
    public abstract Vector3 CalculateAim(Unit target);
}
