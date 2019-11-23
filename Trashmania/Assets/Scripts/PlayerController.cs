using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	[SerializeField] private float speed = 0.1f;
	[SerializeField] private Collider pickupCollider;

	private Rigidbody rd;
	private float xInput, yInput;

	
	void Start() {
		rd = GetComponent<Rigidbody>();
	}

	private void Update() {
		xInput = 0;
		yInput = 0;
		if (Input.GetKey(KeyCode.UpArrow)) {
			yInput += 1;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			xInput += -1;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			xInput += 1;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			yInput += -1;
		}

		if (Input.GetKeyDown(KeyCode.Alpha1)) {

		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {

		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {

		}
		if (Input.GetKeyDown(KeyCode.Alpha4)) {

		}
	}

	private void FixedUpdate() {
		if (xInput == 0 && yInput == 0)
			return;

		float angle = Mathf.Atan2(yInput, xInput);
		float x = Mathf.Cos(angle);
		float y = Mathf.Sin(angle);
		Vector3 moveVector = new Vector3(speed * x, 0, speed * y);
		Vector3 movePosition = transform.position + moveVector;
		//rd.velocity = Vector3.zero;
		//rd.angularVelocity = Vector3.zero;
		rd.MovePosition(movePosition);
		transform.localRotation = Quaternion.LookRotation(moveVector);
	}

	private void Pickup() {
		pickupCollider.enabled = true;
	}
}
