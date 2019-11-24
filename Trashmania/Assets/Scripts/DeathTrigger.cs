using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
	public GameObject deathText = default;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			deathText.SetActive(true);
		}
	}
}
