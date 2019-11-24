using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    [SerializeField]
    private GameObject[] ovens;
    [SerializeField]
    private GameObject[] conveyorBelts;

    [Header("OnRepair conveyorChange")]
    [SerializeField]
    private float onRepairConveyorSpeed;
    [SerializeField]
    private float onRepairConveyorChangeInSeconds;

    private void Awake() {
        if (instance != this) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void OnOvenBroken(int index) {
        if (isGameOver()) {
            GameOver();
        }
    }

    public void OnOvenRepair(int index) {
        StartCoroutine(TemporaryDirectionChange(index));
    }

    private bool isGameOver() {
        bool isAllOvensBroken = true;
        foreach(GameObject ovenGo in ovens) {
            TrashOven oven = ovenGo.GetComponent<TrashOven>();

            if (oven)
                isAllOvensBroken &= oven.GetIsBroken();
        }

        return isAllOvensBroken;
    }

    private void GameOver() {
        UIDelegator.instance.onShowGameOver?.Invoke(true);
        MusicManager.instance.Death();
    }

    private IEnumerator TemporaryDirectionChange(int index) {
        ConveyorBeltMover conveyorBelt = conveyorBelts[index].GetComponent<ConveyorBeltMover>();

        if (conveyorBelt) {
            float originalSpeed = conveyorBelt.speed;

            conveyorBelt.speed = onRepairConveyorSpeed;
            yield return new WaitForSeconds(onRepairConveyorChangeInSeconds);
            conveyorBelt.speed = originalSpeed;
        }
    }
}
