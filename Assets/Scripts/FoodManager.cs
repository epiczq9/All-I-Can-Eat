using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public List<GameObject> spawnableFoodItems;

    public GameObject burgerTrayPrefab;
    public GameObject hotdogTrayPrefab;
    public GameObject tacoTrayPrefab;
    public GameObject ramenTrayPrefab;

    public bool hotdogAdded = false;
    public bool tacosAdded = false;
    public bool ramenAdded = false;
    public bool snailsAdded = false;

    public bool finalFoodAdded = false;

    public float foodWorthMod = 1;

    public int currentFood = 0;

    public GameController gameController;
    void Start() {
        SpawnOrder1();
        //SpawnOrder2();
    }

    void Update() {
        if (Input.GetButtonDown("Fire3")) {
            //SpawnFood();
        }
    }

    void SpawnOrder1() {
        AddRamenToList();
        AddHotDogsToList();
        AddBurgersToList();
        AddTacosToList();
    }

    void SpawnOrder2() {
        AddBurgersToList();
        AddHotDogsToList();
        AddTacosToList();
        AddRamenToList();
    }

    public void AddFood() {
        if (!hotdogAdded) {
            AddHotDogsToList();
        } else if (!tacosAdded) {
            AddTacosToList();
        } else if (!ramenAdded) {
            AddRamenToList();
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

    public void AddRamenToList() {
        spawnableFoodItems.Add(ramenTrayPrefab);
        ramenAdded = true;
        finalFoodAdded = true;
    }
}
