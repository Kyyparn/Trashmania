using Scripts.Enum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static PlayerStats instance;

	public const float HOUR_DURATION = 6f;
	
	private int currentScore;

	private int currentDay;
	private int currentTime;
	private float milli = 1f;

    private Dictionary<TrashType, int> trashSortCount = new Dictionary<TrashType, int>();

    private void Awake() {
        if (instance != this) {
            instance = this;
			UIDelegator.instance.onShowPause += SetTimeScale;
			UIDelegator.instance.onShowGameOver += SetTimeScale;
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

	public int GetTotalScore() {
		return currentScore;
	}

	public int GetTotalDays() {
		return currentDay;
	}

	public int GetTotalHours() {
		return currentTime;
	}

	public int GetTrashCount(TrashType trashType) {
		if (!trashSortCount.ContainsKey(trashType)) {
			return 0;
		}
		return trashSortCount[trashType];
	}

	private void Update() {
		milli += Time.deltaTime;
		if (milli >= HOUR_DURATION) {
			milli -= HOUR_DURATION;

			currentTime++;
			if (currentTime >= 10) {
				currentTime = 0;
				currentDay++;
			}
			UIDelegator.instance.onUpdateTime?.Invoke(currentDay, currentTime);
		}
	}

	public void PauseGame() {
		UIDelegator.instance.onShowPause?.Invoke(true);
	}

	public void SetTimeScale(bool state) {
		Time.timeScale = (state) ? 0 : 1;
	}
}
