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
            var catBullet = colission.GetComponent<CatBullet>();
            if (catBullet.isMoving) return;
            FindObjectOfType<GroupCamera>().moveTo = transform.parent.parent;
            onSpotted.Invoke();
            // Debug.Log("Cat spotted!");
        }
    }
}