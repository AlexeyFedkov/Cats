using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresidentCollider : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _player.inFinalRoom = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _player.inFinalRoom = false;
    }
}
