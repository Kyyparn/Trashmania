﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

	public int entityID;

	[Header("UI components")]
	public Image barFill;


	private void Awake() {
		UIDelegator.instance.onUpdateHealth += UpdateUI;
	}

	private void UpdateUI(int entityId, float percentFill) {
		if (entityID == entityId) {
			barFill.fillAmount = percentFill;
		}
	}
}
