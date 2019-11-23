using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {

	[Header("UI components")]
	public GameObject menuObject;
	public Text scoreText;
	public Text timeText;
	public Text trashCount1;
	public Text trashCount2;
	public Text trashCount3;
	public Text trashCount4;

	private bool visible;


	private void Awake() {
		UpdateUI(false);
		UIDelegator.instance.onShowGameOver += UpdateUI;
	}

	private void UpdateUI(bool state) {
		visible = state;
		menuObject.SetActive(visible);
		if (!visible)
			return;

		scoreText.text = "Score:   " + PlayerStats.instance.GetTotalScore().ToString();
		timeText.text = string.Format("You worked for {0} days and {1} hours", PlayerStats.instance.GetTotalDays(), PlayerStats.instance.GetTotalHours());
		trashCount1.text = "Trash 1:    " + 1234;
		trashCount2.text = "Trash 2:    " + 1234;
		trashCount3.text = "Trash 3:    " + 1234;
		trashCount4.text = "Trash 4:    " + 1234;
	}

	public void ToggleMenu() {
		UIDelegator.instance.onShowGameOver?.Invoke(!visible);
	}
}
