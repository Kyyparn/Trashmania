using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour {

	public int timeOffset = 4;

	[Header("UI components")]
	public Text dayText;
	public Text timeText;

	private int calcTime;
	private int calcMinute;


	private void Awake() {
		UIDelegator.instance.onUpdateTime += UpdateUI;
	}

	private void UpdateUI(int day, int time) {
		dayText.text = "DAY: " + day.ToString();
		calcTime = timeOffset + (time / 60);
		calcMinute = time % 60;
		timeText.text = string.Format("{0} : {1}", calcTime.ToString("00"), calcMinute.ToString("00"));
	}
}
