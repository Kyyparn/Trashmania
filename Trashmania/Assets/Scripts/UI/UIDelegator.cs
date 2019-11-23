using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDelegator : MonoBehaviour {

	public static UIDelegator instance = null;
	private void Awake() {
		if (instance != this) {
			instance = this;
		}
		else {
			Destroy(gameObject);
		}
	}


	public delegate void UpdateScore(int score);
	public UpdateScore onScoreChange;

	public delegate void UpdateTime(int days, int currentTime);
	public UpdateTime onUpdateTime;

	public delegate void UpdateHealth(int entityID, int health);
	public UpdateHealth onUpdateHealth;

	public delegate void ShowScreen(bool state);
	public ShowScreen onShowPause;
	public ShowScreen onShowHelp;

	public delegate void UpdateInventory(int slotID, Material item);
	public UpdateInventory onInventoryChanged;

}
