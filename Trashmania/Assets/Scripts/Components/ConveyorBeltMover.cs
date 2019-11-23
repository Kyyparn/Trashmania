using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltMover : MonoBehaviour
{
	public float speed = 1f;

	[SerializeField]
	private Rigidbody conveyorRB = default;
	private float direction = 1f;

	public void FlipDirecion()
	{
		direction *= -1f;
	}

	void FixedUpdate()
    {
		Vector3 movement = transform.forward * speed * Time.fixedDeltaTime * direction;

		conveyorRB.position -= movement;
		conveyorRB.MovePosition(conveyorRB.position + movement);
	}
}
