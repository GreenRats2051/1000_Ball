using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class BallMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        Entities.WithName("BallMovement").ForEach((ref LocalTransform transform, ref BallMovement movement) =>
        {
            movement.Timer += deltaTime * movement.ZigZagFrequency;

            float forwardMovement = movement.ForwardSpeed * deltaTime;
            float sideMovement = math.sin(movement.Timer) * movement.ZigZagAmplitude * deltaTime;

            transform.Position += new float3(sideMovement, 0f, forwardMovement);
        }).ScheduleParallel();
    }
}