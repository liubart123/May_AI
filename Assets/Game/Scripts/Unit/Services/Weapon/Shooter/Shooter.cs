using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    public float ShootForce;
    /// <summary>
    /// Push bullet in given position
    /// </summary>
    /// <param name="targetPosition"></param>
    public abstract void Shoot(Vector3 targetPosition);
}
