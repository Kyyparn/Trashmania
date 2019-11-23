using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour {

	private void Start() {
		GetComponent<Rigidbody>().AddForce(new Vector3(100f,0f,0f));
		transform.localRotation = Quaternion.Euler(new Vector3(0,Random.Range(-180f,180f), 0f));
	}


	private void OnTriggerEnter(Collider other) {
		if (other.tag != "Oven") {
			return;
		}

		Destroy(gameObject);
	}
}
