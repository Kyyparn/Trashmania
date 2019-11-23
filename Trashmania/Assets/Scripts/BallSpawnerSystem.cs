using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Rendering;

public class BallSpawnerSystem : ComponentSystem
{
	EntityArchetype ball;

	protected override void OnCreate()
	{
		ball = EntityManager.CreateArchetype(typeof(RenderMesh), typeof(Mesh), typeof(Material));
		EntityManager.CreateEntity(ball);
	}

	protected override void OnUpdate()
	{
		
	}
}
