using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDropper : MonoBehaviour {

	[SerializeField] private Transform[] trashObjects = default;
	[SerializeField] private Transform[] dropPoints = default;

	[SerializeField] private float spawnRate = 2f;
	[SerializeField] private float spawnRateVariation = 0.2f;
	[SerializeField] private float daysUntilDoubleSpeed = 7f;
	private float currentTime;
	private float nextSpawnIn;


	private void Update() {
		currentTime -= Time.deltaTime;
		if (currentTime <= 0) {
			SpawnTrash();
			UpdateNextSpawn();
			currentTime += nextSpawnIn;
		}
	}

	private void SpawnTrash() {
		int trashIndex = Random.Range(0, trashObjects.Length);
		int dropIndex = Random.Range(0, dropPoints.Length);

		Instantiate(trashObjects[trashIndex], dropPoints[dropIndex].position, Quaternion.identity);
	}

	private void UpdateNextSpawn() {
		int days = PlayerStats.instance.GetTotalDays();
		nextSpawnIn = spawnRate * daysUntilDoubleSpeed / (daysUntilDoubleSpeed + days) * Random.Range(1f-spawnRateVariation, 1f+spawnRateVariation);
	}
}
