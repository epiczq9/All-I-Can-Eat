using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrayMove : MonoBehaviour
{
    public GameController gameController;
    public GameObject foodTrigger;
    public List<GameObject> trayList;
    public ConveyorBelt conveyorBelt;
    public int currentTray = 0;
    void Start() {
        SetupTrays();
        MoveTrays();
    }

    void Update() {
        if (Input.GetButtonDown("Fire2")) {
            MoveTrays();
        }
    }

    public void SetupTrays() {
        foreach (Transform tray in transform) {
            trayList.Add(tray.gameObject);
        }
    }

    public void MoveTrays() {
        conveyorBelt.StartAnimation();
        gameController.foodGroup = trayList[currentTray].GetComponent<RandomFood>().foodGroupOnTray;
        currentTray++;
        foodTrigger.SetActive(false);
        transform.DOMoveX(transform.position.x + 1, 1.5f).SetEase(Ease.Linear).OnComplete(StartEating);
    }

    public void StartEating() {
        conveyorBelt.StopAnimation();
        foodTrigger.SetActive(true);
        gameController.BeginEating();
    }
}
