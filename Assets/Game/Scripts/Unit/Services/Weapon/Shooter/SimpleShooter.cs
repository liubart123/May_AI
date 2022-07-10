using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShooter : Shooter
{

    [SerializeReference]
    ObjectPool _bulletPool;
    public ObjectPool BulletPool
    {
        get
        {
            if (_bulletPool == null)
            {
                _bulletPool = ObjectPool.FindObjectPool<Bullet>();
            }
            return _bulletPool;
        }
    }

    public override void Shoot(Vector3 targetPosition)
    {
        var bullet = BulletPool?.GetObjectFromPool<Bullet>();
        if (bullet == null)
            return;
        targetPosition.Normalize();
        bullet.transform.position = transform.position;
        var angle = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
        bullet.Shoot(targetPosition * ShootForce, GetComponent<Unit>());
        bullet.onBulletDestroy = () =>
        {
            BulletPool?.ReturnObjectToPool(bullet);
        };
    }

}
