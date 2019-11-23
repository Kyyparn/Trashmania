using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	[SerializeField] private float speed = 0.1f;
	[SerializeField] private PlayerPickup pickup = default;

	private Rigidbody rd;
	private float xInput, yInput;
	private float pickupCooldown;


	private void Start() {
		rd = GetComponent<Rigidbody>();
		UIDelegator.instance.onInventoryChanged?.Invoke(0, null);
		UIDelegator.instance.onInventoryChanged?.Invoke(1, null);
		UIDelegator.instance.onInventoryChanged?.Invoke(2, null);
		UIDelegator.instance.onInventoryChanged?.Invoke(3, null);
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

		if (pickupCooldown > 0) {
			pickupCooldown -= Time.deltaTime;
		}
		else {
			if (Input.GetKeyDown(KeyCode.Alpha1)) {
				PickClick(0);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2)) {
				PickClick(1);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3)) {
				PickClick(2);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha4)) {
				PickClick(3);
			}
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

	private void PickClick(int index) {
		pickupCooldown = 0.3f;
		if (pickup.heldItems[index] == null) {
			pickup.PickUp(index);
		}
		else {
			pickup.Drop(index);
		}
	}
}
