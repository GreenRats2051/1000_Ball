using Unity.Entities;
using UnityEngine;

public class BallAuthoring : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float zigZagAmplitude = 2f;
    public float zigZagFrequency = 3f;
}

public class BallBaker : Baker<BallAuthoring>
{
    public override void Bake(BallAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);

        AddComponent(entity, new BallMovement { ForwardSpeed = authoring.forwardSpeed, ZigZagAmplitude = authoring.zigZagAmplitude, ZigZagFrequency = authoring.zigZagFrequency, Timer = 0f });
        AddComponent<BallTag>(entity);
    }
}