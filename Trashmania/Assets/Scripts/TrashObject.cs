using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour {

	private void Start() {
		transform.localRotation = Quaternion.Euler(new Vector3(0,Random.Range(-180f,180f), 0f));
	}


	private void OnTriggerEnter(Collider other) {
		if (other.tag != "Oven") {
			return;
		}

		Destroy(gameObject);
	}
}
