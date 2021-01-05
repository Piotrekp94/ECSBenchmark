using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class WaveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation t, ref WaveData waveData) =>
        {
            var zPosition = 5 * math.sin((float) Time.ElapsedTime * waveData.speed + t.Value.x * waveData.xOffset + t.Value.z * waveData.zOffset);
            t.Value = new float3(t.Value.x, zPosition, t.Value.z);
        });
    }
}
