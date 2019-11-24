using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour {

	[SerializeField] private int dayTimeOffset = 5;
	[SerializeField] private int nightTimeOffset = 5;
	[SerializeField] private int nightStartsAt = 8;

	[Header("UI components")]
	public Text dayText;
	public Text hourText;

	private int calcTime;


	private void Awake() {
		UpdateUI(0,0);
		UIDelegator.instance.onUpdateTime += UpdateUI;
	}

	private void UpdateUI(int day, int time) {
		dayText.text = (day+1).ToString();
		if (time >= nightStartsAt) {
			time += nightTimeOffset;
		}
		hourText.text = (dayTimeOffset + time).ToString("00");
	}
}
