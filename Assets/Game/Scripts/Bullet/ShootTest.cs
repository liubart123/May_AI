using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ShootTest : MonoBehaviour
{
    public GameObject bullet;
    public VisualEffect shootVfx;
    public VisualEffect hitVfx;
    public TrailRenderer trailRenderer;
    [Range(0,1)]
    public float bulletLifeTime;
    public float bulletSpeed;
    public GameObject[] objectsToHide;
    // Start is called before the first frame update
    void Start()
    {
        //bullet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        bullet.transform.localPosition = Vector3.zero;
        //bullet.SetActive(true);
        foreach(var obj in objectsToHide)
        {
            obj.SetActive(true);
        }
        trailRenderer.Clear();
        shootVfx.Play();
        hitVfx.Stop();
        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * bulletSpeed);
        StartCoroutine(EndShoot());
    }
    
    IEnumerator EndShoot()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        hitVfx.Play();
        bullet.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        foreach (var obj in objectsToHide)
        {
            obj.SetActive(false);
        }
        //yield return new WaitForSeconds(bulletLifeTime);
        //bullet.SetActive(false);
    }

}
