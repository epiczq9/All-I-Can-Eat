using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Timers;

public class TrayMove : MonoBehaviour
{
    public GameController gameController;
    public GameObject foodTrigger;
    public GameObject trayPrefab;
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
        SpawnNewTray();
        trayReady = true;
        conveyorBelt.StopAnimation();
        gameController.BeginEating();
    }

    void SpawnNewTray() {
        if (currentTray >= 2) {
            Destroy(trayList[currentTray - 2]);
        }
        GameObject newTray = Instantiate(trayPrefab, transform);
        newTray.transform.position = new Vector3(-3.13199997f, 0.902999997f, 0.51700002f);
        newTray.GetComponent<RandomFood>().foodManager = GetComponent<FoodManager>();
        trayList.Add(newTray);
    }


}
