using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltMover : MonoBehaviour
{
	public float speed = 1f;

	[SerializeField]
	private Rigidbody conveyorRB = default;
	[SerializeField]
	private Renderer beltRenderer = default;

	private Material mat;
	private float direction = 1f;
	private float uvScrollLength = 0f;

	public void FlipDirecion()
	{
		direction *= -1f;
	}

	private void Awake()
	{
		//Assign copy of material to conveyor belt for UV scrolling
		mat = beltRenderer.material;
		Vector2 uvScale = new Vector2(transform.lossyScale.z, 1f);
		mat.SetTextureScale(Shader.PropertyToID("_MainTex"), uvScale);
	}

	private void Update()
	{
		uvScrollLength -= speed * Time.deltaTime;
		mat.mainTextureOffset = new Vector2(uvScrollLength, 0f);
	}

	void FixedUpdate()
    {
		Vector3 movement = transform.forward * speed * Time.fixedDeltaTime * direction;

		conveyorRB.position -= movement;
		conveyorRB.MovePosition(conveyorRB.position + movement);
	}
}
