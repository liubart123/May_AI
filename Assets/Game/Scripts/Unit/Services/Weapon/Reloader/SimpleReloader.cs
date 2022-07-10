using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleReloader : Reloader
{
    public float cooldown;
    public bool isLoaded = false;
    public override bool IsLoaded()
    {
        return isLoaded;
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(cooldown);
        isLoaded = true;
    }

    public override void Unload()
    {
        isLoaded = false;
        StartCoroutine(Reload());
    }
}
