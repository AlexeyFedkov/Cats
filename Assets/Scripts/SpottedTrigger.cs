using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpottedTrigger : MonoBehaviour
{
    public UnityEvent onSpotted = new UnityEvent(); 
        
    private void OnTriggerEnter2D(Collider2D colission)
    {
        if (colission.CompareTag("Player"))
        {
            onSpotted.Invoke();
            Debug.Log("Cat spotted!");
        }
    }
}