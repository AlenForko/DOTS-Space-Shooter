using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAsteroidMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField]
    private float AsteroidSpeed = 2f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        Vector3 direction = player.transform.position - transform.position;

        transform.position += direction * (AsteroidSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == player)
        {
            Destroy(this.gameObject);
        }
    }
}