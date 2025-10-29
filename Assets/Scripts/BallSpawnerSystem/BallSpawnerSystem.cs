using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class BallSpawnerSystem : SystemBase
{
    private bool _spawned = false;

    protected override void OnUpdate()
    {
        if (_spawned)
            return;

        var query = SystemAPI.QueryBuilder().WithAll<BallSpawner>().Build();

        if (query.IsEmpty)
            return;

        var spawner = SystemAPI.GetSingleton<BallSpawner>();
        var ecb = new EntityCommandBuffer(WorldUpdateAllocator);

        for (int i = 0; i < spawner.BallCount; i++)
        {
            var ball = ecb.Instantiate(spawner.BallPrefab);
            var randomPos = new float3(UnityEngine.Random.Range(-10f, 10f), 0f, UnityEngine.Random.Range(-10f, 10f));

            ecb.SetComponent(ball, LocalTransform.FromPosition(randomPos));
        }

        ecb.Playback(EntityManager);
        _spawned = true;
    }
}

public struct BallSpawner : IComponentData
{
    public Entity BallPrefab;
    public int BallCount;
}