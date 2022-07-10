using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbLinearMover : MonoBehaviour
{
    Rigidbody2D Rigidbody
    {
        get
        {
            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody2D>();
            }
            return _rigidbody;
        }
    }
    Rigidbody2D _rigidbody;
    public float changeDirectionPeriod;
    public Vector2 direction;
    public float speed;

    private void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            Rigidbody.velocity = direction * speed;
            direction = -direction;
            yield return new WaitForSeconds(changeDirectionPeriod);
        }
    }
}
