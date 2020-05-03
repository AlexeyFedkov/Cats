﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;

    private int currentSpot = 0;
    // private int randomSpot;
    // public Transform target;

    private SpriteRenderer _sr;
    private Animator _animator;
    private Rigidbody2D _rb;
    private static readonly int Move = Animator.StringToHash("move");
    private static readonly int Disable1 = Animator.StringToHash("disable");

    private AudioSource _as;
    
    void Start()
    {
        waitTime = startWaitTime;
        _sr = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _as = GetComponent<AudioSource>();
        _as.Play();
        _animator.SetBool(Move, true);

        // randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        var newPosition =
            Vector2.MoveTowards(transform.position, moveSpots[currentSpot].position, speed * Time.deltaTime);
        var shift = newPosition - (Vector2)transform.position;
        var scale = transform.localScale;
        scale.x = Mathf.Sign(shift.x);
        transform.localScale = scale;
        // _sr.flipX = shift.x < 0;
        
        _rb.MovePosition(newPosition);
        if (Vector2.Distance(transform.position, moveSpots[currentSpot].position) < 0.01f)
        {
            if (waitTime <= 0)
            {
                currentSpot = (currentSpot + 1) % moveSpots.Length; 
                // randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
                if (!_as.isPlaying)
                    _as.Play();
                _animator.SetBool(Move, true);
            }
            else
            {
                waitTime -= Time.deltaTime;
                if (_as.isPlaying)
                    _as.Stop();
                _animator.SetBool(Move, false);
            }

            return;
        }
        // Vector2 relativePos = moveSpots[currentSpot].position - transform.position;
        // var angle = Vector2.SignedAngle(Vector2.up, relativePos);
        
        // _rb.SetRotation(angle);
        // Quaternion rotation = Quaternion.LookRotation(relativePos, Vector2.up);
        // transform.rotation = rotation;
    }

    public void Disable()
    {
        _animator.SetTrigger(Disable1);   
        Debug.Log($"Enemy {gameObject.name} disabled");
    }
}
