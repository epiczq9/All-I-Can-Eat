using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public GameController gameController;
    public FoodManager foodManager;
    public FoodEaten foodEaten;

    public int mergePrice = 0;
    public int addFoodPrice = 0;
    public int increaseSpeedPrice = 1000;
    public int increaseIncomePrice = 0;

    public GameObject mergeButton;
    public GameObject addFoodButton;
    public GameObject increaseSpeedButton;
    public GameObject increaseIncomeButton;

    void Start() {
        gameController = GameObject.FindGameObjectWithTag("Woman").GetComponent<GameController>();
    }


    void Update() {

    }

    public void Merge() {
        gameController.ActivateBothHands();
        mergePrice = (int)(mergePrice * 1.2f);
    }


    public void AddFood() {
        foodManager.AddFood();
        addFoodPrice = (int)(addFoodPrice * 1.5f);
    }

    public void IncreaseSpeed() {
        Time.timeScale *= 1.3f;
        increaseSpeedPrice = (int)(increaseSpeedPrice * 2f);
    }

    public void IncreaseIncome() {
        foodManager.foodWorthMod *= 1.2f;
        increaseIncomePrice = (int)(increaseIncomePrice * 2f);
    }
}
