using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {


	[Header("UI components")]
	public Text scoreText;


	private void Start() {
		UIDelegator.instance.onScoreChange += UpdateUI;
	}

	private void UpdateUI(int score) {
		scoreText.text = score.ToString() + " $";
	}
}
