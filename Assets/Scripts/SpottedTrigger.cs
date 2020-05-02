using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpottedTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colission)
    {
        if (colission.TryGetComponent<Player>(out Player player))
        {
            Debug.Log("Cat spotted!");
        }
    }
}