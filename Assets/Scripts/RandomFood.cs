using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class RandomFood : MonoBehaviour
{
    public FoodManager foodManager;

    public GameObject foodGroupOnTray;
    void Start() {
        //TimersManager.SetTimer(this, 0.1f, SpawnFood);
    }

    public void SpawnFood() {
        //foodGroupOnTray = Instantiate(foodManager.spawnableFoodItems[Random.Range(0, foodManager.spawnableFoodItems.Count)], transform);    
        foodGroupOnTray = Instantiate(foodManager.spawnableFoodItems[foodManager.currentFood], transform);
        foodManager.currentFood++;
    }
}
