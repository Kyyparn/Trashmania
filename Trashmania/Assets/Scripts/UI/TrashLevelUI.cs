using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashLevelUI : MonoBehaviour {

	[Header("UI components")]
	public Image barFill;

	
	private void Awake() {
		UIDelegator.instance.onUpdateHealth += UpdateUI;
	}

	private void UpdateUI(int entityId, float percentFill) {
		barFill.fillAmount = percentFill;
	}
}
