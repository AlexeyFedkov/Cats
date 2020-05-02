﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(SpriteRenderer))]
public class IsometricPlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 1f;
    // IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rbody;

    private SpriteRenderer[] _spriteRenderers;
    private Animator[] _animators;
    
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        _animators = GetComponentsInChildren<Animator>();
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        // isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        for (int i = 0; i < _animators.Length; i++)
        {
            _spriteRenderers[i].flipX = horizontalInput < 0;
            _animators[i].SetBool("move", !(Mathf.Approximately(horizontalInput, 0) && Mathf.Approximately(verticalInput, 0)));
        }
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        // isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
    }
}
