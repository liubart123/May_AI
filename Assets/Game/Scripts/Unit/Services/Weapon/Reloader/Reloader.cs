using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reloader : MonoBehaviour
{
    public abstract bool IsLoaded();

    /// <summary>
    /// Unload weapin and start reloading
    /// </summary>
    public abstract void Unload();
}
