using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class CatBullet : MonoBehaviour
{
    private Rigidbody2D _rb;

    public bool isMoving;
    private bool _last;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isMoving) return;
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Patrol>().Disable();
            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("Vision"))
        {
            return;
        }

        if (!other.CompareTag("Player"))
        {
            if (_last)
                GameManager.instance.LastShotGameOver();
            Destroy(gameObject);
        }
    }

    public void StartMove(float speed, bool last = false)
    {
        _last = last;
        isMoving = true;
        _rb.velocity = transform.right * speed;
    }
}
