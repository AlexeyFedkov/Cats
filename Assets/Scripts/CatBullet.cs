using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class CatBullet : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Patrol>().Disable();
        }

        if (!other.CompareTag("Cat"))
        {
            Destroy(gameObject);
        }
    }

    public void StartMove(float speed)
    {
        _rb.velocity = transform.right * speed;
    }
}
