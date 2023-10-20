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
        
        // add player later
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        Config config = SystemAPI.GetSingleton<Config>();

        // Update the time since the last shot
        timeSinceLastFire += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timeSinceLastFire >= config.FireRate)
        {
            var bullet = state.EntityManager.Instantiate(config.BulletPrefab);
                
            state.EntityManager.SetComponentData(bullet, new LocalTransform
            {
                Position = 0f,
                // Set position to be player's position and rotation
            });
        
            state.EntityManager.SetComponentData(bullet, new Velocity
            {
                Value = new float3(0, config.BulletSpeed, 0)
            });

            // Reset the time since the last shot
            timeSinceLastFire = 0f;
        }
    }
}
