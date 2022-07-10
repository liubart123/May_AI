using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRandomMover : MonoBehaviour
{
    public float moveSpeed, tickPeriod;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveTick());
    }

    Vector3 RandomNormalVector3()
    {
        return new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)).normalized;
    }

    IEnumerator MoveTick()
    {
        Rigidbody2D rb;
        rb = GetComponent<Rigidbody2D>();
        while (true)
        {
            Vector2 direction = RandomNormalVector3();
            rb.AddRelativeForce(direction * moveSpeed);
            yield return new WaitForSeconds(tickPeriod);
        }
    }
}
