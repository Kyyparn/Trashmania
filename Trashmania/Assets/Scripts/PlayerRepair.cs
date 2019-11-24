using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRepair : MonoBehaviour
{
    const string REPAIR_TRIGGER_TAG = "RepairTrigger";

    public TrashOven repairOvenRef = null;
	bool isTryingToRepair = false;

    public void UpdateRepairState(bool isTryingToRepair) {
		this.isTryingToRepair = isTryingToRepair;
    }

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == REPAIR_TRIGGER_TAG)
		{
			repairOvenRef = other.gameObject.transform.parent.GetComponent<TrashOven>();

			repairOvenRef?.UpdateRepairState(isTryingToRepair);
		}
	}
}
