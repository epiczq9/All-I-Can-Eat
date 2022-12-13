using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public List<GameObject> spawnableFoodItems;

    public GameObject burgerTrayPrefab;
    public GameObject hotdogTrayPrefab;
    public GameObject tacoTrayPrefab;

    public bool hotdogAdded = false;
    public bool tacosAdded = false;
    public bool snailsAdded = false;

    public float foodWorthMod = 1;

    public GameController gameController;
    void Start() {
        AddBurgersToList();
    }

    void Update() {
        if (Input.GetButtonDown("Fire3")) {
            //SpawnFood();
        }
    }

    public void AddFood() {
        if (!hotdogAdded) {
            AddHotDogsToList();
        } else if (!tacosAdded) {
            AddTacosToList();
        } else {

        }
    }

    public void AddBurgersToList() {
        spawnableFoodItems.Add(burgerTrayPrefab);
    }

    public void AddHotDogsToList() {
        spawnableFoodItems.Add(hotdogTrayPrefab);
        hotdogAdded = true;
    }

    public void AddTacosToList() {
        spawnableFoodItems.Add(tacoTrayPrefab);
        tacosAdded = true;
    }
}
