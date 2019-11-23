using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using Unity.Collections;
using Unity.Mathematics;

public class Testing : MonoBehaviour
{
    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;


    // Start is called before the first frame update
    void Start()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        EntityArchetype ea = entityManager.CreateArchetype(
            typeof(TrashComponent),
            typeof(Translation),
            typeof(RenderMesh),
            typeof(LocalToWorld)
        );

        NativeArray<Entity> entityArray = new NativeArray<Entity>(3000, Allocator.Temp);
        entityManager.CreateEntity(ea, entityArray);

        foreach(Entity entity in entityArray)
        {
            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = mesh,
                material = material
            });
            entityManager.SetComponentData(entity, new Translation
            {
                Value = new float3(UnityEngine.Random.Range(-2.5f, 2.5f), UnityEngine.Random.Range(-1.5f, 1.5f), 0)
            });
        }

        entityArray.Dispose();
    }
}
