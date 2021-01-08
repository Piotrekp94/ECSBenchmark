using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class WaveJobSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation t, ref WaveData waveData) =>
        {
            var zPosition = waveData.amplitude * getFunctionBasedOnDesiredFunction(waveData, t);
            t.Value = new float3(t.Value.x, zPosition, t.Value.z);
        });
    }

    private float getFunctionBasedOnDesiredFunction(WaveData waveData, Translation t)
    {
        if (waveData.desiredFunctionEnum == DesiredFunctionEnum.Sin)
            return math.sin((float) Time.ElapsedTime * waveData.speed + t.Value.x * waveData.xOffset +
                            t.Value.z * waveData.zOffset);
        if (waveData.desiredFunctionEnum == DesiredFunctionEnum.SquareWave)
            return math.sign(math.sin((float) Time.ElapsedTime * waveData.speed + t.Value.x * waveData.xOffset +
                                      t.Value.z * waveData.zOffset));

        return (float) (Time.ElapsedTime * waveData.speed / 10 + t.Value.x * waveData.xOffset +
            t.Value.z * waveData.zOffset - math.floor(t.Value.x * waveData.xOffset +
                                                      t.Value.z * waveData.zOffset +
                                                      Time.ElapsedTime * waveData.speed / 10 + 0.5f));
    }
}