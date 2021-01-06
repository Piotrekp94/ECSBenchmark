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

public class mcSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;
    [SerializeField] private Text text;
    
    [SerializeField] private float amplitude;
    [SerializeField] private float speed;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private DesiredFunctionEnum desiredFunctionEnum;

    private List<Entity> entites;
    private int count = 0;
    private EntityManager _entityManager;
    private void Start()
    {
        entites = new List<Entity>();
        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        for (var i = 0; i < 100; i++)
        {
            for (var j = 0; j < 100; j++)
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
                entites.Add(e);
                count++;
            }
        }

        text.text = count.ToString();
    }

    private void Update()
    {
        entites.ForEach(entity => _entityManager.AddComponentData(entity, new WaveData(amplitude, speed, xOffset, yOffset, desiredFunctionEnum)));
    }
}