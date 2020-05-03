﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(SpriteRenderer))]
public class IsometricPlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 1f;
    // IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rbody;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        // isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        _spriteRenderer.flipX = horizontalInput < 0;
        _animator.SetBool("move", !(Mathf.Approximately(horizontalInput, 0) && Mathf.Approximately(verticalInput, 0)));
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        // isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
    }
}
