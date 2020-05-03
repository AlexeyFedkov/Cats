using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HideTileCollider : MonoBehaviour
{
    private TilemapRenderer tilemapRender;

    private void Awake()
    {
        tilemapRender = GetComponent<TilemapRenderer>();
    }


    void Start()
    {
        tilemapRender.enabled = false;
    }

}
