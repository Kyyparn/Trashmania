using Scripts.Enum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour {

    [SerializeField]
    private TrashType trashType;

	private void Start() {
		transform.localRotation = Quaternion.Euler(new Vector3(0,Random.Range(-180f,180f), 0f));
	}

    public TrashType GetTrashType() {
        return trashType;
    }
}
