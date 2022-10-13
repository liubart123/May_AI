using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitShootTest : MonoBehaviour
{
    public Unit unit1, unit2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            unit1.WeaponService.Shoot(unit2);
        }
    }
}
