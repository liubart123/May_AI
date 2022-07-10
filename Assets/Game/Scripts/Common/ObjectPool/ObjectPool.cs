using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public int initialPoolSize;
    public GameObject prefab;

    /// <summary>
    /// bool -> is object already used 
    /// </summary>
    protected Dictionary<GameObject, bool> pool = new Dictionary<GameObject, bool>();
    public virtual void CreateInitialPool()
    {
        for(int i = 0; i < initialPoolSize; i++)
        {
            CreatePoolObject();
        }
    }
    protected virtual GameObject CreatePoolObject()
    {
        var obj = Instantiate(prefab, transform);
        pool.Add(obj, false);
        obj.gameObject.SetActive(false);
        return obj;
    }
    public virtual T GetObjectFromPool<T> () where T : MonoBehaviour
    {
        foreach (var poolObject in pool)
        {
            if (poolObject.Value == false)
            {
                pool[poolObject.Key] = true;
                poolObject.Key.gameObject.SetActive(true);
                return poolObject.Key.GetComponent<T>();
            }
        }

        var result = CreatePoolObject();
        pool[result] = true;
        result.gameObject.SetActive(true);
        return result.GetComponent<T>();
    }
    public virtual void ReturnObjectToPool<T>(T obj) where T : MonoBehaviour
    {
        pool[obj.gameObject] = false;
        obj.gameObject.SetActive(false);
    }


    void Start()
    {
        CreateInitialPool();
    }

    public static ObjectPool FindObjectPool<T>() where T : MonoBehaviour
    {
        var pools = FindObjectsOfType<ObjectPool>();
        foreach (var pool in pools)
        {
            if (pool.prefab is T)
            {
                return pool;
            }
        }
        return null;
    }
}
