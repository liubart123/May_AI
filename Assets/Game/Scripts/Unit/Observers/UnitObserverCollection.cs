using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitObserverCollection : MonoBehaviour
{

    [HideInInspector]
    private Unit owner;
    public UnitsInRangeObserver unitsInShootRange, unitsInViewRange;

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

    void Start()
    {
        InitializeRangeObservers();
    }


    public void InitializeRangeObservers()
    {
        if (unitsInShootRange != null)
            unitsInShootRange.owner = Owner;
        if (unitsInViewRange != null)
            unitsInViewRange.owner = Owner;
    }
}
