using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct WaveData : IComponentData
{
    public int speed;
    public float xOffset;
    public float zOffset;

    public WaveData(int i, float xOffset, float zOffset)
    {
        speed = i;
        this.xOffset = xOffset;
        this.zOffset = zOffset;
    }
}
