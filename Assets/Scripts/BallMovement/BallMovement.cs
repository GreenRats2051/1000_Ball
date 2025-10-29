using Unity.Entities;
using Unity.Mathematics;

public struct BallMovement : IComponentData
{
    public float ForwardSpeed;
    public float ZigZagAmplitude;
    public float ZigZagFrequency;
    public float Timer;
}

public struct BallTag : IComponentData { }