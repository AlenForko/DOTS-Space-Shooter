using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct BulletSpawnerSystem : ISystem
{
    private float timeSinceLastFire;
    
    
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Config>();
        state.RequireForUpdate<Player>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        Config config = SystemAPI.GetSingleton<Config>();

        // Update the time since the last shot
        timeSinceLastFire += Time.deltaTime;

        //Gets player transform
        LocalTransform playerTransform = SystemAPI.GetComponentRO<LocalTransform>(SystemAPI.GetSingleton<Player>().Entity).ValueRO;
        
        if (Input.GetKeyDown(KeyCode.Space) && timeSinceLastFire >= config.FireRate)
        {
            var bullet = state.EntityManager.Instantiate(config.BulletPrefab);

            float3 forwardVector = math.mul(playerTransform.Rotation, new float3(0, 1, 0));

            float3 spawnOffset = forwardVector * 1.2f;

            float3 spawnPos = playerTransform.Position + spawnOffset;
            
            state.EntityManager.SetComponentData(bullet, new LocalTransform
            {
                Position = spawnPos,
                Rotation = playerTransform.Rotation,
                Scale = 1f
            });
        
            state.EntityManager.SetComponentData(bullet, new Velocity
            {
                Value = forwardVector * config.BulletSpeed
            });

            // Reset the time since the last shot
            timeSinceLastFire = 0f;
        }
    }
}
