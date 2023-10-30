using Unity.Entities;
using UnityEngine;


public class ConfigAuthoring : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject AsteroidPrefab;
    public GameObject BulletPrefab;
    public GameObject PlayerPrefab;
    
    [Header("Player Stats")]
    public float PlayerTurnSpeed = 10f;
    
    [Header("Bullet Stats")]
    public float BulletSpeed = 10f;
    public float FireRate = 0.5f;
    public float BulletLifeSpan = 3f;

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
                PlayerPrefab = GetEntity(configAuthoring.PlayerPrefab, TransformUsageFlags.Dynamic),
                PlayerTurnSpeed = configAuthoring.PlayerTurnSpeed,
                BulletSpeed = configAuthoring.BulletSpeed,
                FireRate = configAuthoring.FireRate,
                BulletLifeSpan = configAuthoring.BulletLifeSpan,
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
    public Entity PlayerPrefab;
    public float PlayerTurnSpeed;
    public float BulletSpeed;
    public float FireRate;
    public float BulletLifeSpan;
    public float AsteroidSpawnFreq;
    public float AsteroidSpeed;
    public float AsteroidSpawnRadius;
    public int AsteroidSpawnAmount;
}
