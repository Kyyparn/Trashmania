using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour {

	[SerializeField] private float pickupDistance = 1f;
	[SerializeField] private float dropDistance = 1f;
	[SerializeField] private Vector3 dropOffset = new Vector3(0, 0, 0.6f);

	public GameObject[] heldItems = new GameObject[4];
	private float searchDistance;


	public bool PickUp(int index) {
		Vector3 pickPosition = transform.position;
		Collider closestObject = null;
		searchDistance = float.MaxValue;
		Collider[] hitColliders = Physics.OverlapSphere(pickPosition, pickupDistance);
		for (int i = 0; i < hitColliders.Length; i++) {
			if (hitColliders[i].tag != "Trash")
				continue;
			float angle = Vector3.Angle(pickPosition, hitColliders[i].transform.position);
			if (Mathf.Abs(angle) < searchDistance) {
				searchDistance = Mathf.Abs(angle);
				closestObject = hitColliders[i];
			}
		}
		if (closestObject != null) {
			GameObject other = closestObject.gameObject;
			heldItems[index] = other.gameObject;
			UIDelegator.instance.onInventoryChanged?.Invoke(index, other.GetComponentInChildren<Renderer>().material);
			other.gameObject.SetActive(false);
			return true;
		}
		return false;
	}

	public void Drop(int index) {
		if (heldItems[index] != null) {
			Vector3 dropVector = transform.position + dropDistance * transform.forward + dropOffset;
			heldItems[index].transform.position = dropVector;
			heldItems[index].transform.rotation = Quaternion.identity;
			heldItems[index].SetActive(true);
			heldItems[index] = null;
			UIDelegator.instance.onInventoryChanged?.Invoke(index, null);
		}
	}

}
