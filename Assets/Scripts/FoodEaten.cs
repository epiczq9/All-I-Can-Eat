using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEaten : MonoBehaviour
{
    public GameObject wholeFood;
    public GameObject halfFood;
    bool halfEaten = false;
    public float worth;
    public float worthMod = 1;

    GameController eater;
    public FoodManager foodManager;

    private void Start() {
        eater = GameObject.FindGameObjectWithTag("Woman").GetComponent<GameController>();
        foodManager = GameObject.FindGameObjectWithTag("FoodManager").GetComponent<FoodManager>();
    }
    public void TakeABite() {
        if (!halfEaten) {
            EatHalf();
        } else {
            FinishFood();
        }
    }

    public void EatHalf() {
        halfFood.SetActive(true);
        wholeFood.SetActive(false);
        halfEaten = true;
    }

    public void FinishFood() {
        eater.money += (int)(worth * foodManager.foodWorthMod);
        Destroy(gameObject);
        //gameController.FinishedFood();
    }    
}
