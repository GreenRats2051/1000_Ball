using Unity.Entities;
using UnityEngine;

public class CounterAuthoring : MonoBehaviour
{
    public int initialValue = 0;
}

public class CounterBaker : Baker<CounterAuthoring>
{
    public override void Bake(CounterAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new Counter { Value = authoring.initialValue });
    }
}