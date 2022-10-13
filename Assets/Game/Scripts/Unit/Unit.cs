using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [HideInInspector]
    private WeaponService weaponService;
    [HideInInspector]
    private MovementService movementService;
    [HideInInspector]
    private UnitObserverCollection unitObserverCollection;
    [HideInInspector]
    private UnitBehaviorController unitBehaviorController;

    public int fraction;

    public WeaponService WeaponService {
        get {
            if (weaponService == null)
                weaponService = GetComponent<WeaponService>();
            return weaponService;
        }
        set => weaponService = value; 
    }
    public MovementService MovementService {
        get
        {
            if (movementService == null)
                movementService = GetComponent<MovementService>();
            return movementService;
        }
        set => movementService = value; }
    public UnitObserverCollection UnitObserverCollection
    {
        get
        {
            if (unitObserverCollection == null)
                unitObserverCollection = GetComponent<UnitObserverCollection>();
            return unitObserverCollection;
        }
        set => unitObserverCollection = value;
    }
    public UnitBehaviorController UnitBehaviorController
    {
        get
        {
            if (unitBehaviorController == null)
                unitBehaviorController = GetComponent<UnitBehaviorController>();
            return unitBehaviorController;
        }
        set => unitBehaviorController = value;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
