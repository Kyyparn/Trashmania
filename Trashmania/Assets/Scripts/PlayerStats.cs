using Scripts.Enum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static PlayerStats instance;

	private int currentScore;

	private int currentDay = 10;
	private int currentTime;
	private float milli = 1f;

    private Dictionary<TrashType, int> trashSortCount = new Dictionary<TrashType, int>();

    private void Awake() {
        if (instance != this) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void AddCorrectSortedTrash(TrashType trashType) {
        if (!trashSortCount.ContainsKey(trashType)) {
            trashSortCount.Add(trashType, 0);
        }

        trashSortCount[trashType]++;

        //TODO: Give different score for different trash
		currentScore += 50;

		UIDelegator.instance.onScoreChange?.Invoke(currentScore);
	}

	private void Update() {
		milli += Time.deltaTime;
		if (milli >= 1f) {
			milli -= 1f;

			currentTime++;
			UIDelegator.instance.onUpdateTime?.Invoke(currentDay, currentTime);
		}
	}

	public void PauseGame() {
		UIDelegator.instance.onShowPause?.Invoke(true);
	}
}
