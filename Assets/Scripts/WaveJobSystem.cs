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
        if (waveData.desiredFunctionEnum == DesiredFunctionEnum.Sin)
            return math.sin(elapsedTime * waveData.speed + translation.Value.x * waveData.xOffset +
                            translation.Value.z * waveData.zOffset);
        if (waveData.desiredFunctionEnum == DesiredFunctionEnum.SquareWave)
            return math.sign(math.sin(elapsedTime * waveData.speed + translation.Value.x * waveData.xOffset +
                                      translation.Value.z * waveData.zOffset));

        return elapsedTime * waveData.speed / 10 + translation.Value.x * waveData.xOffset +
            translation.Value.z * waveData.zOffset - math.floor(translation.Value.x * waveData.xOffset +
                                                                translation.Value.z * waveData.zOffset +
                                                                elapsedTime * waveData.speed / 10 + 0.5f);
    }
}