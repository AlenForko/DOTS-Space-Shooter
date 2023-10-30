using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[UpdateBefore(typeof(AsteroidsMovement))]
public partial struct BulletCollision : ISystem
{
   [BurstCompile]
   public void OnCreate(ref SystemState state)
   {
      state.RequireForUpdate<Asteroid>();
      state.RequireForUpdate<Player>();
   }
   
   [BurstCompile]
   public void OnUpdate(ref SystemState state)
   {
      Config config = SystemAPI.GetSingleton<Config>();
      float outerRadius = config.AsteroidSpawnRadius;
      foreach (var (bulletTransform, bulletEntity) in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<Bullet>().WithEntityAccess())
      {
         foreach (var (asteroidTransform, asteroidEntity) in SystemAPI.Query<RefRW<LocalTransform>>()
                     .WithAll<Asteroid>().WithEntityAccess())
         {
            if (!(math.distance(bulletTransform.ValueRO.Position, asteroidTransform.ValueRO.Position) < 0.5f)) continue;
            
            SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged).DestroyEntity(asteroidEntity);
         }

         float distanceFromCenter = math.distance(bulletTransform.ValueRO.Position, float3.zero);
         if (distanceFromCenter > outerRadius)
         {
            SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged).DestroyEntity(bulletEntity);
         }
      }
   }
}
