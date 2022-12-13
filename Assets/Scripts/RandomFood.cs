using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFood : MonoBehaviour
{
    public FoodManager foodManager;

    public GameObject foodGroupOnTray;
    void Start() {
        foodGroupOnTray = Instantiate(foodManager.spawnableFoodItems[Random.Range(0, foodManager.spawnableFoodItems.Count)], transform);
    }
}
