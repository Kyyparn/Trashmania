using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

	public int entityID;
	public float maxHealth;

	[Header("UI components")]
	public Image healthFill;


	private void Awake() {
		UIDelegator.instance.onUpdateHealth += UpdateUI;
	}

	private void UpdateUI(int entityId, int health) {
		if (entityID == entityId) {
			healthFill.fillAmount = (health / maxHealth);
		}
	}
}
