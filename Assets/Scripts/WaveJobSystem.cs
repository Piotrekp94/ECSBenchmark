using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class WaveJobSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var elapsedTime = (float) Time.ElapsedTime;
        Entities.ForEach((ref Translation translation, ref WaveData waveData) =>
        {
            var zPosition = waveData.amplitude * getFunctionBasedOnDesiredFunction(waveData, translation, elapsedTime);
            translation.Value = new float3(translation.Value.x, zPosition, translation.Value.z);
        }).ScheduleParallel();
    }

    private static float getFunctionBasedOnDesiredFunction(WaveData waveData, Translation translation,
        float elapsedTime)
    {
        var x = elapsedTime * waveData.speed + translation.Value.x * waveData.xOffset +
                translation.Value.z * waveData.zOffset;
        return waveData.desiredFunctionEnum switch
        {
            DesiredFunctionEnum.Sin => math.sin(x),
            DesiredFunctionEnum.SquareWave => math.sign(math.sin(x)),
            DesiredFunctionEnum.SawtoothWave => x - math.floor(x + 0.5f),
            DesiredFunctionEnum.TriangleWave => 4 * (x - 0.5f * math.floor(2 * x + 0.5f)) *
                                                math.pow(-1, math.floor(2 * x + 0.5f)),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}