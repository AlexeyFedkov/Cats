using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public KeyCode shootKey = KeyCode.Space;
    public float catBulletSpeed = 1;
    public Text catsCounter;

    private Camera _camera;

    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();
    }

    private void Start()
    {
        UpdateText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            if (transform.childCount > 1)
            {
                var currentCat = transform.GetChild(0);
                var direction = Input.mousePosition - _camera.WorldToScreenPoint(currentCat.position);

                var eulers = currentCat.eulerAngles;
                eulers.z = Vector2.SignedAngle(Vector2.right, direction);
                currentCat.eulerAngles = eulers;
                
                currentCat.parent = null;
                currentCat.GetComponent<CatBullet>().StartMove(catBulletSpeed);
                
                UpdateText();
            }
        }
    }

    private void UpdateText()
    {
        if (catsCounter)
            catsCounter.text = transform.childCount.ToString();
    }
}