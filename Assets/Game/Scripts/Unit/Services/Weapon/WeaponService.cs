using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponService : MonoBehaviour
{
    [HideInInspector]
    private Aimer aimer;
    [HideInInspector]
    private Shooter shooter;
    [HideInInspector]
    private Reloader reloader;
    [HideInInspector]
    private Unit owner;

    public float shootRange;

    public Aimer Aimer
    {
        get
        {
            if (aimer == null)
                aimer = GetComponent<Aimer>();
            return aimer;
        }
        set => aimer = value; }
    public Shooter Shooter
    {
        get
        {
            if (shooter == null)
                shooter = GetComponent<Shooter>();
            return shooter;
        }
        set => shooter = value; }
    public Reloader Reloader
    {
        get
        {
            if (reloader == null)
                reloader = GetComponent<Reloader>();
            return reloader;
        }
        set => reloader = value;
    }

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

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public virtual void Initialize()
    {
        if (Aimer == null)
            Aimer = GetComponent<Aimer>();
        if (Shooter == null)
            Shooter = GetComponent<Shooter>();
        if (Reloader == null)
            Reloader = GetComponent<Reloader>();
    }

    public abstract void Shoot(Unit target);
}
