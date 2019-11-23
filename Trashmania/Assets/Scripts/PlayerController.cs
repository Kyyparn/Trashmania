using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	[SerializeField] private float speed = 0.1f;
	[SerializeField] private PlayerPickup pickup = default;

	[SerializeField] private float pickupCooldDown = 0.5f;

	//[SerializeField] private List<Transform> graphicsToFlip = 0.5f;

	private Rigidbody rigidBody;
	private float xInput, zInput;
	private float pickupCooldownLeft;


	private void Start() {
		rigidBody = GetComponent<Rigidbody>();
		UIDelegator.instance.onInventoryChanged?.Invoke(0, null);
		UIDelegator.instance.onInventoryChanged?.Invoke(1, null);
		UIDelegator.instance.onInventoryChanged?.Invoke(2, null);
		UIDelegator.instance.onInventoryChanged?.Invoke(3, null);
	}

	private void Update() {
		xInput = 0;
		zInput = 0;
		if (Input.GetKey(KeyCode.UpArrow)) {
			zInput += 1;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			xInput += -1;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			xInput += 1;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			zInput += -1;
		}

		if (pickupCooldownLeft > 0) {
			pickupCooldownLeft -= Time.deltaTime;
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
		if (xInput == 0 && zInput == 0)
			return;

		Vector2 inputVectorNorm = new Vector2(xInput, zInput).normalized;

		Vector2 movementVector2D = inputVectorNorm * speed * Time.fixedDeltaTime;

		Vector3 movePosition = transform.position + new Vector3(movementVector2D.x, 0f, movementVector2D.y);

		rigidBody.MovePosition(movePosition);

		transform.localRotation = GetLookRotation(inputVectorNorm);
	}

	//Snap player rotation to x-axis aligned y-rotation
	private Quaternion GetLookRotation(Vector3 movementDirection)
	{
		float lookProjX = Vector3.Dot(movementDirection, Vector3.right);

		Vector3 lookDirection = lookProjX > 0f ? Vector3.right : Vector3.left;

		return Quaternion.LookRotation(lookDirection);
	}

	private void PickClick(int index) {
		pickupCooldownLeft = pickupCooldDown;
		if (pickup.heldItems[index] == null) {
			pickup.PickUp(index);
		}
		else {
			pickup.Drop(index);
		}
	}
}
