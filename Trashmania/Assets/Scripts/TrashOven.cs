using Scripts.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashOven : MonoBehaviour {
	const float MAX_HEALTH = 100;

    const string TRASH_TAG = "Trash";
    const string PLAYER_TAG = "Player";

    [Header("Oven info")]
    [SerializeField] protected int entityID;
    [SerializeField] protected TrashType acceptedTrash;

    [Header("Oven health")]
    [SerializeField] protected int health;
    [SerializeField] protected int damageOnFail;
    [SerializeField] protected bool isBroken;

    [Header("Oven repair")]
    [SerializeField] protected int healthPerTick;
    [SerializeField] protected float tickTimeInSeconds;
    [SerializeField] protected int repairHealthThreshold;

    protected bool inRepairRange = false;
    protected bool isRepairing = false;
    protected float currentRepairTime = 0f;

    private void Start() {
        health = (int)MAX_HEALTH;
        UIDelegator.instance.onUpdateHealth?.Invoke(entityID, health/MAX_HEALTH);
    }

    private void FixedUpdate() {
        if (isRepairing) {
            float newRepairTime = currentRepairTime + Time.fixedDeltaTime;

            if (newRepairTime >= tickTimeInSeconds) {
                Heal();
                newRepairTime -= tickTimeInSeconds;
            }

            currentRepairTime = newRepairTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == TRASH_TAG && !isBroken) {
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
            isBroken = true;
            print($"OVEN {entityID} is BROKEN!");
        }

        UIDelegator.instance.onUpdateHealth?.Invoke(entityID, health / MAX_HEALTH);
    }

    private void Heal() {
        health += healthPerTick;

        if (isBroken) {
            if (health >= repairHealthThreshold) {
                isBroken = false;
            }
        }

        UIDelegator.instance.onUpdateHealth?.Invoke(entityID, health);
    }

    public void UpdateRepairState(bool isRepairing) {
        this.isRepairing = isRepairing;
        currentRepairTime = 0f;
    }
}
