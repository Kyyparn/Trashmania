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

	public delegate void UpdateBarFill(int entityID, float barFill);
	public UpdateBarFill onUpdateHealth;
	public UpdateBarFill onUpdateTrash;

	public delegate void ShowScreen(bool state);
	public ShowScreen onShowPause;
	public ShowScreen onShowHelp;
	public ShowScreen onShowGameOver;

	public delegate void UpdateInventory(int slotID, Material item);
	public UpdateInventory onInventoryChanged;

}
