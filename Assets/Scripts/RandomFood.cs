using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFood : MonoBehaviour
{
    public List<GameObject> spawnableFoodItems;

    public GameObject burgerTrayPrefab;
    public GameObject hotdogTrayPrefab;
    public GameObject tacoTrayPrefab;
    public GameObject foodGroupOnTray;

    public GameController gameController;

    public int numberOfTrays = 3;
    void Start() {
        AddHotDogsToList();
        AddTacosToList();
        spawnableFoodItems.Add(burgerTrayPrefab);
        foodGroupOnTray = Instantiate(spawnableFoodItems[Random.Range(0, spawnableFoodItems.Count)], transform);
    }

    void Update() {
        if (Input.GetButtonDown("Fire3")) {
            //SpawnFood();
        }
    }

    public void SpawnFood() {
        
    }

    public void AddHotDogsToList() {
        spawnableFoodItems.Add(hotdogTrayPrefab);
    }

    public void AddTacosToList() {
        spawnableFoodItems.Add(tacoTrayPrefab);
    }


}
