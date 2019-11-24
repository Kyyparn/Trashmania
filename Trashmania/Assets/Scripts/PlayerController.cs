using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	enum LookDirection
	{
		LEFT = 1,
		RIGHT = -1
	}

	[SerializeField] private float speed = 0.1f;
	[SerializeField] private PlayerPickup pickup = default;

	[SerializeField] private float pickupCooldDown = 0.5f;
	[SerializeField] private Transform graphicsRoot = default;

	private SpriteRenderer[] spriteRenderers = default;
	private int numRenderers = default;

	private Rigidbody rigidBody;
	private float xInput, zInput;
	private float pickupCooldownLeft;
	private LookDirection lookDirection = LookDirection.RIGHT;

	private void Start() {
		rigidBody = GetComponent<Rigidbody>();

		spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

		//Offset by num renderers to always be above zero when flipping order later
		//Being below zero causes them to render below boxes
		numRenderers = spriteRenderers.Length;
		foreach (SpriteRenderer spriteRenderer in spriteRenderers)
		{
			spriteRenderer.sortingOrder += numRenderers;
		}

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

		LookDirection newLookDirection = DetermineLookRotation(inputVectorNorm);

		if(newLookDirection != lookDirection)
		{
			lookDirection = newLookDirection;
			transform.localRotation = CalculateLookDirection(newLookDirection);
			FlipCharacterGraphics();
		}
	}

	//Snap player rotation to x-axis aligned y-rotation
	private LookDirection DetermineLookRotation(Vector3 movementDirection)
	{
		float lookProjX = Vector3.Dot(movementDirection, Vector3.right);
		return lookProjX > 0f ? LookDirection.RIGHT : LookDirection.LEFT;
	}

	private Quaternion CalculateLookDirection(LookDirection direction)
	{
		Vector3 lookDirection = direction == LookDirection.RIGHT ? Vector3.right : Vector3.left;
		return Quaternion.LookRotation(lookDirection);
	}

	private void FlipCharacterGraphics()
	{
		Vector3 localRot = graphicsRoot.localRotation.eulerAngles;

		localRot.x *= -1f;

		graphicsRoot.localRotation = Quaternion.Euler(localRot);
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
