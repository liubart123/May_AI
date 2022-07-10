using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponService : MonoBehaviour
{
    [HideInInspector]
    public Aimer aimer;
    [HideInInspector]
    public Shooter shooter;
    [HideInInspector]
    public Reloader reloader;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public virtual void Initialize()
    {
        if (aimer == null)
            aimer = GetComponent<Aimer>();
        if (shooter == null)
            shooter = GetComponent<Shooter>();
        if (reloader == null)
            reloader = GetComponent<Reloader>();
    }

    public abstract void Shoot(Unit target);
}
