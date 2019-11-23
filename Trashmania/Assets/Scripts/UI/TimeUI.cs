using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour {

	public int timeOffset = 4;

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
		hourText.text = (timeOffset + time).ToString("00");
	}
}
