using Scripts.Enum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    [Header("Score")]
    [SerializeField]
    [Min(0)]
    private int sortedScore = default;
    [SerializeField]
    private int repairScorePenalty = default;

    public static PlayerStats instance;

	[SerializeField] private float hourDuration = 4f;
	
	private int currentScore;

	private int currentDay;
	private int currentTime;
	private float milli = 1f;

    private Dictionary<TrashType, int> trashSortCount = new Dictionary<TrashType, int>();
    private Dictionary<TrashType, int> ovensRepairedCount = new Dictionary<TrashType, int>();

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
		currentScore += sortedScore;

		UIDelegator.instance.onScoreChange?.Invoke(currentScore);
	}

    public void AddOvenRepairCompleted(TrashType trashType) {
        if (!ovensRepairedCount.ContainsKey(trashType)) {
            trashSortCount.Add(trashType, 0);
        }

        trashSortCount[trashType]++;

        currentScore += repairScorePenalty;

        if (currentScore < 0)
            currentScore = 0;

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

	public float GetHourMinutes() {
		return currentTime + milli / hourDuration;
	}

	public int GetTrashCount(TrashType trashType) {
		if (!trashSortCount.ContainsKey(trashType)) {
			return 0;
		}
		return trashSortCount[trashType];
	}

	private void Update() {
		milli += Time.deltaTime;
		if (milli >= hourDuration) {
			milli -= hourDuration;

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
