using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour {

	[Header("UI components")]
	public GameObject pauseMenuObject;

	private bool visible;


	private void Start() {
		UpdateUI(false);
		UIDelegator.instance.onShowPause += UpdateUI;
	}

	private void UpdateUI(bool state) {
		visible = state;
		pauseMenuObject.SetActive(visible);
	}

	public void ToggleMenu() {
		UpdateUI(!visible);
	}
}
