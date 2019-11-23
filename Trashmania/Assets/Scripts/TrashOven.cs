using Scripts.Enum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashOven : MonoBehaviour {
	const float MAX_HEALTH = 100;
    const string TRASH_TAG = "Trash";

    [Header("Oven info")]
    [SerializeField] protected int entityID;
    [SerializeField] protected TrashType acceptedTrash;

    [Header("Oven health")]
    [SerializeField] protected int health;
    [SerializeField] protected int damageOnFail;
    [SerializeField] protected bool broken;

	[SerializeField] private Renderer healthBarRenderer = default;
	private Material mat = null;


	private void Start() {
        UIDelegator.instance.onUpdateHealth?.Invoke(entityID, health/MAX_HEALTH);
		mat = healthBarRenderer.material;
		mat.SetFloat("_HealthPercent", health / MAX_HEALTH);
		healthBarRenderer.material = mat;
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == TRASH_TAG && !broken) {
            if (other.gameObject.GetComponent<TrashObject>()?.GetTrashType() == acceptedTrash) {
                PlayerStats.instance.AddCorrectSortedTrash(other.gameObject.GetComponent<TrashObject>().GetTrashType());
            }
            else {
                TakeDamage();
            }

            Destroy(other.gameObject);
        }
    }

    private void TakeDamage() {
        health -= damageOnFail;

        if (health <= 0) {
            health = 0;
            broken = true;
            print($"OVEN {entityID} is BROKEN!");
        }

        UIDelegator.instance.onUpdateHealth?.Invoke(entityID, health / MAX_HEALTH);
		Material mat = healthBarRenderer.material;
		mat.SetFloat("_HealthPercent",health / MAX_HEALTH);
		healthBarRenderer.material = mat;
    }
	
}
