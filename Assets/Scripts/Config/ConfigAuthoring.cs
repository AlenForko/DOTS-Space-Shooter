using Unity.Entities;
using UnityEngine;


public class ConfigAuthoring : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject AsteroidPrefab;
    public GameObject BulletPrefab;
    
    [Header("Player Stats")]
    public float PlayerSpeed = 10f;
    public int PlayerHealth = 3;
    
    [Header("Bullet Stats")]
    public float BulletSpeed = 10f;
    public float FireRate = 0.5f;

    [Header("Asteroid Stats")] 
    public float AsteroidSpawnFreq = 1f;
    public float AsteroidSpeed = 10f;
    public float AsteroidSpawnRadius = 10f;
    public int AsteroidSpawnAmount = 100;

    class Baker : Baker<ConfigAuthoring>
    {
        public override void Bake(ConfigAuthoring configAuthoring) 
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            
            AddComponent(entity, new Config
            {
                AsteroidPrefab = GetEntity(configAuthoring.AsteroidPrefab, TransformUsageFlags.Dynamic),
                BulletPrefab = GetEntity(configAuthoring.BulletPrefab, TransformUsageFlags.Dynamic),
                PlayerSpeed = configAuthoring.PlayerSpeed,
                PlayerHealth = configAuthoring.PlayerHealth,
                BulletSpeed = configAuthoring.BulletSpeed,
                FireRate = configAuthoring.FireRate,
                AsteroidSpawnFreq = configAuthoring.AsteroidSpawnFreq,
                AsteroidSpeed = configAuthoring.AsteroidSpeed,
                AsteroidSpawnRadius = configAuthoring.AsteroidSpawnRadius,
                AsteroidSpawnAmount = configAuthoring.AsteroidSpawnAmount
            });
        }
    }
}

public struct Config : IComponentData
{
    public Entity AsteroidPrefab;
    public Entity BulletPrefab;
    public float PlayerSpeed;
    public int PlayerHealth;
    public float BulletSpeed;
    public float FireRate;
    public float AsteroidSpawnFreq;
    public float AsteroidSpeed;
    public float AsteroidSpawnRadius;
    public int AsteroidSpawnAmount;
}
