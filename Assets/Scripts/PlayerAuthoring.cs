using Unity.Entities;
using UnityEngine;

public class PlayerAuthoring : MonoBehaviour
{
    class Baker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring playerAuthoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Player()
            {
                Entity = entity
            });
        }
    }
}

public struct Player : IComponentData
{
    public Entity Entity;
}