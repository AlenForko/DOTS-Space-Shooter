using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MAsteroidSpawn : MonoBehaviour
{
    private float _LastSpawnTime;
    private float spawnRadius = 10;
    private const float TAU = Mathf.PI * 2;

    [SerializeField]
    private int _SpawnAmount = 1000;

    [SerializeField] 
    private Rigidbody2D AsteroidPrefab;

    private void Update()
    {
        _LastSpawnTime += Time.deltaTime;

        if (_LastSpawnTime >= 1f)
        {
            for (int i = 0; i < _SpawnAmount; i++)
            {
                spawnRadius = Random.Range(spawnRadius, spawnRadius + 5f);
                float angle = Random.Range(0f, TAU);
                float xPos = spawnRadius * Mathf.Cos(angle);
                float yPos = spawnRadius * Mathf.Sin(angle);

                Vector2 SpawnPos = new Vector2(xPos, yPos);

                Rigidbody2D AsteroidRb = Instantiate(AsteroidPrefab, SpawnPos, Quaternion.identity);
            }
        }
    }
}
