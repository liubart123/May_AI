using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Bullet : MonoBehaviour
{

    public VisualEffect shootVfx;
    public VisualEffect hitVfx;
    public TrailRenderer trailRenderer;
    public GameObject[] objectsToHide;
    public Action onBulletDestroy;
    public Unit shooter;


    public virtual void Shoot(Vector2 forceDirection, Unit shooter)
    {
        StopCoroutine(EndShotAfterSomeTime());
        foreach (var obj in objectsToHide)
        {
            obj.SetActive(true);
        }
        trailRenderer.Clear();
        GetComponent<Rigidbody2D>().velocity = forceDirection;
        //GetComponent<Rigidbody2D>().AddForce(forceDirection, ForceMode2D.Impulse);
        //GetComponent<Rigidbody2D>().AddForce(forceDirection);
        shootVfx.gameObject.SetActive(true);
        hitVfx.gameObject.SetActive(false);
        this.shooter = shooter;
        StartCoroutine(EndShotAfterSomeTime());
    }

    public virtual IEnumerator EndShoot()
    {
        hitVfx.gameObject.SetActive(true);
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        foreach (var obj in objectsToHide)
        {
            obj.SetActive(false);
        }
        yield return new WaitForSeconds(3);
        onBulletDestroy();
    }

    public virtual IEnumerator EndShotAfterSomeTime()
    {
        yield return new WaitForSeconds(10);
        yield return EndShoot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 7 || collision.gameObject.GetComponent<Unit>() == shooter)
            return;

        StartCoroutine(EndShoot());
    }
}
