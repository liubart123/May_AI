using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Runs weapon and movement action
/// Chooses weapon and movement action
/// </summary>
public abstract class UnitBehaviorController : MonoBehaviour
{
    [HideInInspector]
    private UnitDecisionMaker unitDecisionMaker;
    [HideInInspector]
    private Unit owner;
    public float periodOfImplementingAction;
    public float periodOfDecisionMaking;
    public UnitMovementAction movementAction;
    public UnitWeaponAction weaponAction;
    public Vector2 pointOfInterest;

    public Unit Owner { get  {
            if (owner == null)
            {
                owner = GetComponent<Unit>();
            }
            return owner;
        }
        set => owner = value; }
    public UnitDecisionMaker UnitDecisionMaker
    {
        get
        {
            if (unitDecisionMaker == null)
                unitDecisionMaker = GetComponent<UnitDecisionMaker>();
            return unitDecisionMaker;
        }
        set => unitDecisionMaker = value;
    }

    void Start()
    {
        UnitDecisionMaker.Initialize();
        StartCoroutine(ImplementActionsPeriodically());
        StartCoroutine(MakeDecisions());
    }

    public virtual IEnumerator ImplementActionsPeriodically()
    {
        while (true)
        {
            movementAction?.ImplementMovementAction();
            weaponAction?.ImplementWeaponAction();
            yield return new WaitForSeconds(periodOfImplementingAction);
        }
    }
    public virtual IEnumerator MakeDecisions()
    {
        while (true)
        {
            movementAction = UnitDecisionMaker?.ChooseMovementAction();
            weaponAction = UnitDecisionMaker?.ChooseWeaponAction();
            yield return new WaitForSeconds(periodOfDecisionMaking);
        }
    }

}
