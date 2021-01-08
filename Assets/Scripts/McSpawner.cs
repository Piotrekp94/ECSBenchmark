using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class McSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField][ReadOnly] private Mesh mesh;
    [SerializeField] private Material material;
    
    [SerializeField] private int gridSizeX;
    [SerializeField] private int gridSizeY;
    [SerializeField] private float amplitude;
    [SerializeField] private float speed;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private DesiredFunctionEnum desiredFunctionEnum;

    private List<Entity> _entites;
    private EntityManager _entityManager;
    private void Start()
    {
        _entites = new List<Entity>();
        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        for (var i = 0; i < gridSizeX; i++)
        {
            for (var j = 0; j < gridSizeY; j++)
            {
                var archetype = _entityManager.CreateArchetype(
                    typeof(Translation),
                    typeof(Rotation),
                    typeof(RenderMesh),
                    typeof(RenderBounds),
                    typeof(LocalToWorld));
                var e = _entityManager.CreateEntity(archetype);
                _entityManager.AddComponentData(e, new Translation {Value = new float3(i,  0f, j)});
                _entityManager.AddComponentData(e, new WaveData(amplitude, speed, xOffset, yOffset, desiredFunctionEnum));
                _entityManager.AddSharedComponentData(e, new RenderMesh {mesh = mesh, material = material});
                _entites.Add(e);
            }
        }
    }

    public void UpdateData()
    {
        _entites.ForEach(entity => _entityManager.AddComponentData(entity, new WaveData(amplitude, speed, xOffset, yOffset, desiredFunctionEnum)));
    }
}