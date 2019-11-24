using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRepair : MonoBehaviour
{
    TrashOven repairOvenRef = null;

    public void UpdateRepairState(bool repairState) {
        repairOvenRef?.UpdateRepairState(repairState);
    }

    private void OnRepairRangeEnter(TrashOven oven) {
        if (!repairOvenRef) {
            repairOvenRef = oven;
            print($"REPAIR RANGE ENTERED FOR {oven.name}");
        }
    }

    private void OnRepairRangeExit(TrashOven oven) {
        if (repairOvenRef.Equals(oven)) {
            repairOvenRef = null;
            print($"REPAIR RANGE EXIT FOR {oven.name}");
        }
    }
}
