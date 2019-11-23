using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpUI : MonoBehaviour {

	[Header("UI components")]
	public GameObject menuObject;

	private bool visible;


	private void Start() {
		UpdateUI(false);
		UIDelegator.instance.onShowHelp += UpdateUI;
	}

	private void UpdateUI(bool state) {
		visible = state;
		menuObject.SetActive(visible);
	}

	public void ToggleMenu() {
		UpdateUI(!visible);
	}
}
