using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpTest : MonoBehaviour
{
    UnitHpRenderer unitHpRenderer;
    public float speed = 0.0001f;
    public float HP;
    void Start()
    {
        unitHpRenderer = GetComponent<UnitHpRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HP += speed;
        if (HP > 1)
            HP = 0;
        unitHpRenderer.HP = HP;
    }
}
