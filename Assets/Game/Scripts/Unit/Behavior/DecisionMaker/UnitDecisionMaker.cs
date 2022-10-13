using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitDecisionMaker : MonoBehaviour
{
    [HideInInspector]
    private Unit owner;
    public Unit Owner
    {
        get
        {
            if (owner == null)
            {
                owner = GetComponent<Unit>();
            }
            return owner;
        }
        set => owner = value;
    }

    public abstract UnitMovementAction ChooseMovementAction();
    public abstract UnitWeaponAction ChooseWeaponAction();
    public abstract void Initialize();
}
