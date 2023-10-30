using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public partial struct AsteroidSpawnerSystem : ISystem
{
    private float _LastSpawnTime;
    private float spawnRadius;
    private const float TAU = Mathf.PI * 2;

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Config>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        Config config = SystemAPI.GetSingleton<Config>();

        _LastSpawnTime += Time.deltaTime;
        
        if (_LastSpawnTime >= config.AsteroidSpawnFreq)
        {
            for (int i = 0; i < config.AsteroidSpawnAmount; i++)
            {
                Entity asteroid = state.EntityManager.Instantiate(config.AsteroidPrefab);
                
                spawnRadius = Random.Range(config.AsteroidSpawnRadius, config.AsteroidSpawnRadius + 5f);
                float angle = Random.Range(0f, TAU);
                float xPos = spawnRadius * Mathf.Cos(angle);
                float yPos = spawnRadius * Mathf.Sin(angle);

                SystemAPI.GetComponentRW<LocalTransform>(asteroid).ValueRW.Position = new float3(xPos, yPos, 0);
            }
            _LastSpawnTime = 0f;
        }
    }
}
