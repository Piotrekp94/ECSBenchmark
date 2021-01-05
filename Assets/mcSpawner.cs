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
    [SerializeField] private Mesh _mesh;
    [SerializeField] private Material _material;
    [SerializeField] private Text _text;

    private int count = 0;
    private int x = 0;
    private int z = 0;
    private void Start()
    {
        
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                var archetype = entityManager.CreateArchetype(
                    typeof(Translation),
                    typeof(Rotation),
                    typeof(RenderMesh),
                    typeof(RenderBounds),
                    typeof(LocalToWorld));
                var e = entityManager.CreateEntity(archetype);
                entityManager.AddComponentData(e, new Translation {Value = new float3(i,  0f, j)});
                entityManager.AddComponentData(e, new WaveData(2, 0.1f, 0.1f));
                entityManager.AddSharedComponentData(e, new RenderMesh {mesh = _mesh, material = _material});
            
                count++;
            }
        }

        _text.text = count.ToString();
    }
}