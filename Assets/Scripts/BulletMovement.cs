using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[UpdateBefore(typeof(TransformSystemGroup))]
public partial struct BulletMovement : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Config>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        Config config = SystemAPI.GetSingleton<Config>();

        foreach (var (bulletTransform, velocity) in
                 SystemAPI.Query<RefRW<LocalTransform>, RefRW<Velocity>>().WithAll<Bullet>())
        {
            float3 newPosition = bulletTransform.ValueRW.Position +
                                 new float3(velocity.ValueRO.Value.x, velocity.ValueRO.Value.y, 0f) 
                                 * SystemAPI.Time.DeltaTime * config.BulletSpeed;

            bulletTransform.ValueRW.Position = newPosition;
        }
    }
}
