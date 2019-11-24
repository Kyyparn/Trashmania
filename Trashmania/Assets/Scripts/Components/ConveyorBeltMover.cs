using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltMover : MonoBehaviour
{
	public float speed = 1f;
	public float speedJitterStrength = 0.4f;
	public float speedJitterChangeRate = 3f;
	private float speedJitterChangeAccumulator = 0f;
	private float speedJitterAccumulator = 0f;

	[SerializeField]
	private float uvScaleFactor = 0.5f;

	[SerializeField]
	private Rigidbody conveyorRB = default;
	[SerializeField]
	private Renderer beltRenderer = default;

	private Material mat;
	private float direction = 1f;
	private float uvScrollLength = 0f;

	private void Awake()
	{
		//Assign copy of material to conveyor belt for UV scrolling
		mat = beltRenderer.material;
		Vector2 uvScale = new Vector2(transform.lossyScale.z * uvScaleFactor, 1f);
		mat.SetTextureScale(Shader.PropertyToID("_MainTex"), uvScale);

		//Randomize initial uv scroll
		uvScrollLength = Random.Range(0f, 1f);
	}

	private void Update()
	{
		float dt = Time.deltaTime;

		uvScrollLength -= ((speed + speedJitterAccumulator) * dt * uvScaleFactor) % 1f;
		mat.mainTextureOffset = new Vector2(uvScrollLength, 0f);
	}

	void FixedUpdate()
    {
		float dt = Time.fixedDeltaTime;

		CalculateJitter(ref speedJitterAccumulator, ref speedJitterChangeAccumulator, speedJitterStrength, speedJitterChangeRate, dt);

		Vector3 movement = transform.forward * (speed + speedJitterAccumulator) * dt;

		conveyorRB.position -= movement;
		conveyorRB.MovePosition(conveyorRB.position + movement);
	}

	private static void CalculateJitter(ref float jitterAccumulator, ref float jitterChangeAccumulator, float strength, float changeRate, float dt)
	{
		float randomJitterChange = Random.Range(-changeRate, changeRate);
		jitterChangeAccumulator = Mathf.Clamp(jitterChangeAccumulator + randomJitterChange * dt, -strength * 0.5f, strength * 0.5f);

		jitterAccumulator = Mathf.Clamp(jitterAccumulator + jitterChangeAccumulator * dt, -strength, strength);
	}
}
