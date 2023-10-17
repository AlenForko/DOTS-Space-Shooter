using Unity.Entities;
using UnityEngine;

public class AsteroidAuthoring : MonoBehaviour
{
    class Baker : Baker<AsteroidAuthoring>
    {
        public override void Bake(AsteroidAuthoring asteroidAuthoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent( entity, new Asteroid()
            {
                
            });
        }
    }
}

public struct Asteroid : IComponentData
{
        
}
