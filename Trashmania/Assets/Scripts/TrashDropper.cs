using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDropper : MonoBehaviour {
	
	public Transform[] trashObjects;
	public Transform[] dropPoints;

	public float spawnRate = 2f;
	private float currentTime;


	private void SpawnTrash() {
		int trashIndex = Random.Range(0, trashObjects.Length);
		int dropIndex = Random.Range(0, dropPoints.Length);

		Instantiate(trashObjects[trashIndex], dropPoints[dropIndex].position, Quaternion.identity);
	}

	private void Update() {
		currentTime += Time.deltaTime;
		if (currentTime >= spawnRate) {
			currentTime -= spawnRate;
			SpawnTrash();
		}
	}
}
