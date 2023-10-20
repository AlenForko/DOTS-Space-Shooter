using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class BulletAuthoring : MonoBehaviour
{
    class Baker : Baker<BulletAuthoring>
    {
        public override void Bake(BulletAuthoring bulletAuthoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Bullet());
            AddComponent(entity, new Velocity());
        }
    }
}

public struct Bullet : IComponentData
{

}

public struct Velocity : IComponentData
{
    public float3 Value;
}
