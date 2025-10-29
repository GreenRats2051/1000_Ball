using Unity.Entities;

public partial class CounterSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Counter counter) => { counter.Value++; }).ScheduleParallel();
    }
}