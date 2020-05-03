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

    [Space] 
    public Sprite frontCatBullet;
    public Sprite backCatBullet;

    [Space] private GroupCamera _gp;
    private Camera _camera;

    private void Awake()
    {
        _gp = FindObjectOfType<GroupCamera>();
        _camera = FindObjectOfType<Camera>();
    }

    private void Start()
    {
        UpdateText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(shootKey) && transform.childCount > 1)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var currentCat = transform.GetChild(0);
        _gp.observables.Remove(currentCat);
        var direction = Input.mousePosition - _camera.WorldToScreenPoint(currentCat.position);

        var sr = currentCat.GetComponent<SpriteRenderer>();
        sr.flipY = direction.x <= 0;
        // sr.flipY = direction.y 
        sr.sprite = direction.y > 0 ? backCatBullet : frontCatBullet;
        Destroy(currentCat.GetComponent<Animator>());
        Destroy(currentCat.GetComponent<IsometricPlayerMovementController>());
        currentCat.GetComponent<CircleCollider2D>().isTrigger = true;
        
        var eulers = currentCat.eulerAngles;
        eulers.z = Vector2.SignedAngle(Vector2.right, direction);
        currentCat.eulerAngles = eulers;
                
        currentCat.parent = null;
        currentCat.GetComponent<CatBullet>().StartMove(catBulletSpeed);
                
        UpdateText();
    }

    private void UpdateText()
    {
        if (catsCounter)
            catsCounter.text = transform.childCount.ToString();
    }
}