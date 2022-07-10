using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsInRangeObserver : MonoBehaviour
{
    public Unit owner;
    public CircleCollider2D triggerRange;
    public List<Unit> allies, enemies;

    private void Start()
    {
        var hits = Physics2D.CircleCastAll(transform.position, triggerRange.radius, Vector2.zero, 0.001f, LayerMask.GetMask("Unit"));
        if (hits != null)
        {
            foreach(var hit in hits)
            {
                if (hit.collider?.gameObject == null)
                    continue;
                var unit = hit.collider.gameObject.GetComponent<Unit>();
                if (unit == owner || unit == null)
                    continue;
                AddUnit(unit);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.GetMask("Unit"))
            return;

        var unit = collision.gameObject.GetComponent<Unit>();
        AddUnit(unit);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.GetMask("Unit"))
            return;

        var unit = collision.gameObject.GetComponent<Unit>();
        RemoveUnit(unit);

    }
    private void AddUnit(Unit unit)
    {
        if (unit == null)
            return;
        if (unit.fraction == owner.fraction)
        {
            allies.Add(unit);
        }
        else
        {
            enemies.Add(unit);
        }
    }
    private void RemoveUnit(Unit unit)
    {
        if (unit == null)
            return;
        if (unit.fraction == owner.fraction)
        {
            allies.Remove(unit);
        }
        else
        {
            enemies.Remove(unit);
        }
    }
}
