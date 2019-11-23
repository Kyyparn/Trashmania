using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour {

	[Header("UI components")]
	public GameObject menuObject;

	private bool visible;


	private void Awake() {
		UpdateUI(false);
		UIDelegator.instance.onShowPause += UpdateUI;
	}

	private void UpdateUI(bool state) {
		visible = state;
		menuObject.SetActive(visible);
	}

	public void ToggleMenu() {
		UIDelegator.instance.onShowPause?.Invoke(!visible);
	}
}
