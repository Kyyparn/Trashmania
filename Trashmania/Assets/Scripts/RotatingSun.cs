using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSun : MonoBehaviour {

	[SerializeField] Vector2 activeHours = new Vector2(0,8);
	[SerializeField] Vector2 rotation = new Vector2(0,8);
	[SerializeField] Light sunLight = default;
	bool currentActive = false;


	// Update is called once per frame
	void Update() {
		float time = PlayerStats.instance.GetHourMinutes();
		bool isDay = (time >= activeHours.x && time < activeHours.y);

		currentActive = isDay;
		sunLight.enabled = isDay;
		if (isDay) {
			float percent = (time - activeHours.x) / (activeHours.y - activeHours.x);
			transform.localRotation = Quaternion.Euler(Mathf.Lerp(rotation.x, rotation.y, percent), 0, 0);
		}
	}
}
