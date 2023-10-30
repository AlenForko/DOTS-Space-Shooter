using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBullet : MonoBehaviour
{
    private GameObject _Player;
    
    [SerializeField]
    private GameObject _Offset;

    private float _TimeSinceLastFired;

    [SerializeField] 
    private float _BulletSpeed = 1;

    [SerializeField] 
    private Rigidbody2D _BulletPrefab;

    private void Start()
    {
        _Player = this.gameObject;
    }

    void Update()
    {
        _TimeSinceLastFired += Time.deltaTime;
        
        if (Input.GetKey(KeyCode.Space) && _TimeSinceLastFired >= 0.1f)
        {
            Rigidbody2D rbBullet = Instantiate(_BulletPrefab, _Offset.transform.position, _Player.transform.rotation);
            rbBullet.AddForce(_Player.transform.up * _BulletSpeed);
            _TimeSinceLastFired = 0;
        }
    }
}
