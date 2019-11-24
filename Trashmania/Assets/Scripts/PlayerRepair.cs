using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRepair : MonoBehaviour
{
    const string REPAIR_TRIGGER_TAG = "RepairTrigger";

    TrashOven repairOvenRef = null;

    public void UpdateRepairState(bool repairState) {
        repairOvenRef?.UpdateRepairState(repairState);
    }

    private void OnRepairRangeEnter(TrashOven oven) {
        if (!repairOvenRef) {
            repairOvenRef = oven;
        }
    }

    private void OnRepairRangeExit(TrashOven oven) {
        if (repairOvenRef != null) {
            if (repairOvenRef.Equals(oven)) {
                repairOvenRef.UpdateRepairState(false);
                repairOvenRef = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == REPAIR_TRIGGER_TAG) {
            TrashOven oven = other.gameObject.transform.parent.GetComponent<TrashOven>();

            if (oven)
                OnRepairRangeEnter(oven);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == REPAIR_TRIGGER_TAG) {
            TrashOven oven = other.gameObject.transform.parent.GetComponent<TrashOven>();

            if (oven)
                OnRepairRangeExit(oven);
        }
    }
}
