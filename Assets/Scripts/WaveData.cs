using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct WaveData : IComponentData
{
    public float speed;
    public float amplitude;
    public float xOffset;
    public float zOffset;
    public DesiredFunctionEnum desiredFunctionEnum;

    public WaveData(float amplitude, float speed, float xOffset, float zOffset, DesiredFunctionEnum desiredFunctionEnum)
    {
        this.desiredFunctionEnum = desiredFunctionEnum;
        this.amplitude = amplitude;
        this.speed = speed;
        this.xOffset = xOffset;
        this.zOffset = zOffset;
    }
}
