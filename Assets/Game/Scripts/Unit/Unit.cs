using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [HideInInspector]
    public WeaponService weaponService;
    [HideInInspector]
    public UnitObserverCollection unitObserverCollection;

    public int fraction;
    // Start is called before the first frame update
    void Start()
    {
        if (weaponService == null)
            weaponService = GetComponent<WeaponService>();
        if (unitObserverCollection == null)
            unitObserverCollection = GetComponent<UnitObserverCollection>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
