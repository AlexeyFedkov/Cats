using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GroupCamera : MonoBehaviour
{
    public List<Transform> observables;
    [Range(0, 1)]
    public float lerpSpeed;

    public Transform moveTo;

    private Vector3 prevPosition;
    private float z;

    private void Start()
    {
        z = transform.position.z;
        prevPosition = AveragePosition();
        transform.position = prevPosition;
    }
    
    private void Update()
    {
        var newPos = Vector3.Lerp(prevPosition, moveTo ? moveTo.position + Vector3.back * 10 : AveragePosition(), lerpSpeed);
        prevPosition = newPos;
        transform.position = newPos;
    }

    private Vector3 AveragePosition()
    {
        var pos = Vector3.zero;
        for (int i = 0; i < observables.Count; i++)
        {
            pos += observables[i].position;
        }

        pos /= observables.Count;
        pos.z = z;
        return pos;
    }
}
