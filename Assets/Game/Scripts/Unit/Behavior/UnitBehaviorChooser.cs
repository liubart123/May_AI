using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviorController : MonoBehaviour
{
    public UnitMovementAction movementAction;
    public UnitWeaponAction weaponAction;
    public Unit owner;
    public float periodOfImplementingAction;

    void Start()
    {
        owner = GetComponent<Unit>();
        StartCoroutine(ImplementActionsPeriodically());
    }

    public IEnumerator ImplementActionsPeriodically()
    {
        while (true)
        {
            ChooseMovementAction();
            movementAction.ImplementMovementAction();
            weaponAction.ImplementWeaponAction();
            yield return new WaitForSeconds(periodOfImplementingAction);
        }
    }

    public void ChooseMovementAction()
    {

    }
    public void ChooseWeaponAction()
    {

    }
}
