﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;

    private int currentSpot = 0;
    // private int randomSpot;
    // public Transform target;
    
    void Start()
    {
        waitTime = startWaitTime;
        // randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[currentSpot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[currentSpot].position) < 0.3f)
        {
            if (waitTime <= 0)
            {
                currentSpot = (currentSpot + 1) % moveSpots.Length; 
                // randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

            return;
        }
        Vector2 relativePos = moveSpots[currentSpot].position - transform.position;
        var angle = Vector2.Angle(Vector2.up, relativePos);
        
        var euler = transform.eulerAngles;
        euler.z = angle;
        transform.eulerAngles = euler;
        // Quaternion rotation = Quaternion.LookRotation(relativePos, Vector2.up);
        // transform.rotation = rotation;
    }
}
