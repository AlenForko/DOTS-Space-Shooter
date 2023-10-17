using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] 
    private float _BulletSpeed = 1;

    [SerializeField] 
    private Rigidbody2D _BulletPrefab;

    [SerializeField] 
    private GameObject _Player;

    private void Start()
    {
        _Player = gameObject;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 spawnPosition = _Player.transform.position;

            Rigidbody2D rbBullet = Instantiate(_BulletPrefab, spawnPosition, _Player.transform.rotation);
            rbBullet.AddForce(_Player.transform.up * _BulletSpeed);
            
            Destroy(rbBullet.gameObject, 2);
        }
        
    }
}
