using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateBefore(typeof(TransformSystemGroup))]
public partial struct AsteroidsMovement : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Config>();
        state.RequireForUpdate<Player>();
        state.RequireForUpdate<Asteroid>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        Config config = SystemAPI.GetSingleton<Config>();

        //Player is always at 0,0,0 so no need to find the player any other way
        float3 playerPos = float3.zero;

        
        foreach (var (asteroidTransform, asteroidPrefab) in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<Asteroid>().WithEntityAccess())
        {
            float3 dir = math.normalize(playerPos - asteroidTransform.ValueRO.Position);

            asteroidTransform.ValueRW.Position += dir * SystemAPI.Time.DeltaTime * config.AsteroidSpeed;
            
            if (math.distance(asteroidTransform.ValueRO.Position, playerPos) <= 0.5f)
            {
                SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged).DestroyEntity(asteroidPrefab);
            }
        }
    }
}