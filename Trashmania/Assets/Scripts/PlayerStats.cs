using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	private int currentScore;

	private int currentDay = 10;
	private int currentTime;
	private float milli = 1f;

	private int[] machines = new int[]{ 99, 99, 99, 99 };


	public void GainScore() {
		currentScore += 50;
		UIDelegator.instance.onScoreChange?.Invoke(currentScore);
	}

	private void Update() {
		milli += Time.deltaTime;
		if (milli >= 1f) {
			milli -= 1f;

			currentTime++;
			UIDelegator.instance.onUpdateTime?.Invoke(currentDay, currentTime);

			for (int i = 0; i < machines.Length; i++) {
				if (machines[i] < 100) {
					machines[i] = Mathf.Min(100, machines[i] + 4);
					UIDelegator.instance.onUpdateHealth(i, machines[i]);
				}
			}
		}
	}

	public void DamageMachine(int entityId) {
		machines[entityId] = Mathf.Max(0, machines[entityId] - 25);
		UIDelegator.instance.onUpdateHealth?.Invoke(entityId, machines[entityId]);
	}

	public void PauseGame() {
		UIDelegator.instance.onShowPause?.Invoke(true);
	}
}
