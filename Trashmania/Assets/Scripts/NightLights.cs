using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightLights : MonoBehaviour {

	[SerializeField] Vector2 activeHours = new Vector2(8, 16);
	public Light[] nightLights;
	private bool currentNight;


	void Update() {
		bool isNight = (PlayerStats.instance.GetTotalHours() >= activeHours.x && PlayerStats.instance.GetTotalHours() < activeHours.y);
		if (currentNight != isNight) {
			currentNight = isNight;
			for (int i = 0; i < nightLights.Length; i++) {
				nightLights[i].enabled = isNight;
			}
		}
	}
}
