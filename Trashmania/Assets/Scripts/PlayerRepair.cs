using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRepair : MonoBehaviour
{
    [SerializeField]
    private float repairRange;

    TrashOven repairOvenRef = null;

    public void Repair() {
        repairOvenRef?.UpdateRepairState(true);
    }

    public void StopRepair() {
        repairOvenRef?.UpdateRepairState(false);
    }

    private void OnRepairRangeEnter(TrashOven oven) {
        if (!repairOvenRef)
            repairOvenRef = oven;
    }

    private void OnRepairRangeExit(TrashOven oven) {
        if (repairOvenRef.Equals(oven)) {
            repairOvenRef = null;
        }
    }
}
