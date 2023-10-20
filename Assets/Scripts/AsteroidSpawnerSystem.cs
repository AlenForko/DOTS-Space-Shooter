using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public partial struct AsteroidSpawnerSystem : ISystem
{
    private float _LastSpawnTime;
    
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
                float angle = Random.Range(0f, Mathf.PI * 2);

                float xPos = config.AsteroidSpawnRadius * Mathf.Cos(angle);
                float yPos = config.AsteroidSpawnRadius * Mathf.Sin(angle);
                
                
                Entity asteroid = state.EntityManager.Instantiate(config.AsteroidPrefab);

                SystemAPI.GetComponentRW<LocalTransform>(asteroid).ValueRW.Position = new float3(xPos, yPos, 0);
            }
            
            _LastSpawnTime = 0f;
        }
    }
}
