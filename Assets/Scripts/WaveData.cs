using Unity.Entities;

public struct WaveData : IComponentData
{
    public readonly float speed;
    public readonly float amplitude;
    public readonly float xOffset;
    public readonly float zOffset;
    public readonly DesiredFunctionEnum desiredFunctionEnum;

    public WaveData(float amplitude, float speed, float xOffset, float zOffset, DesiredFunctionEnum desiredFunctionEnum)
    {
        this.desiredFunctionEnum = desiredFunctionEnum;
        this.amplitude = amplitude;
        this.speed = speed;
        this.xOffset = xOffset;
        this.zOffset = zOffset;
    }
}