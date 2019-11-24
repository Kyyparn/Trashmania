using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

	[Header("UI components")]
	public Image[] itemIcon;


	private void Awake() {
		UIDelegator.instance.onInventoryChanged += UpdateUI;
	}

	private void UpdateUI(int slotID, Sprite item) {
		itemIcon[slotID].sprite = item;
	}
}
