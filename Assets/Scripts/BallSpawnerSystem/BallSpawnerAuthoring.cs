using Unity.Entities;
using UnityEngine;

public class BallSpawnerAuthoring : MonoBehaviour
{
    public GameObject ballPrefab;
    public int ballCount = 1000;
}

public class BallSpawnerBaker : Baker<BallSpawnerAuthoring>
{
    public override void Bake(BallSpawnerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.None);

        AddComponent(entity, new BallSpawner
        {
            BallPrefab = GetEntity(authoring.ballPrefab, TransformUsageFlags.Dynamic),
            BallCount = authoring.ballCount
        });
    }
}