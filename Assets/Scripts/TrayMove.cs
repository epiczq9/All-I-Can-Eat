using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Timers;

public class TrayMove : MonoBehaviour
{
    public GameController gameController;
    public GameObject foodTrigger;
    public List<GameObject> trayList;
    public ConveyorBelt conveyorBelt;
    public int currentTray = 0;
    public bool trayReady = false;
    void Start() {
        SetupTrays();
        TimersManager.SetTimer(this, 0.1f, MoveTrays);
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
        trayReady = false;
        trayList[currentTray].GetComponent<RandomFood>().SpawnFood();
        conveyorBelt.StartAnimation();
        gameController.foodGroup = trayList[currentTray].GetComponent<RandomFood>().foodGroupOnTray;
        currentTray++;
        transform.DOMoveX(transform.position.x + 1, 1.5f).SetEase(Ease.Linear).OnComplete(StartEating);
    }

    public void StartEating() {
        trayReady = true;
        conveyorBelt.StopAnimation();
        gameController.BeginEating();
    }
}
