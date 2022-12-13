using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetup : MonoBehaviour
{
    public GameController gameController;

    public int mergePrice = 0;
    public int addFoodPrice = 0;
    public int increaseSpeedPrice = 0;
    public int increaseIncomePrice = 0;

    public GameObject mergeButton;
    public GameObject addFoodButton;
    public GameObject increaseSpeedButton;
    public GameObject increaseIncomeButton;

    void Start() {
        gameController = GameObject.FindGameObjectWithTag("Woman").GetComponent<GameController>();
    }


    void Update() {
        SetupMergeButton();
        SetupAddFoodButton();
        SetupIncreaseSpeedButton();
        SetupIncreaseIncomeButton();

    }

    void ActivateButton(GameObject buttonObj) {
        buttonObj.GetComponent<Button>().interactable = true;
    }

    void DeactivateButton(GameObject buttonObj) {
        buttonObj.GetComponent<Button>().interactable = false;
    }

    void SetupMergeButton() {
        if (gameController.money >= mergePrice) {
            ActivateButton(mergeButton);
        } else {
            DeactivateButton(mergeButton);
        }
    }

    void SetupAddFoodButton() {
        if (gameController.money >= addFoodPrice) {
            ActivateButton(addFoodButton);
        } else {
            DeactivateButton(addFoodButton);
        }
    }

    void SetupIncreaseSpeedButton() {
        if (gameController.money >= increaseSpeedPrice) {
            ActivateButton(increaseSpeedButton);
        } else {
            DeactivateButton(increaseSpeedButton);
        }
    }

    void SetupIncreaseIncomeButton() {
        if (gameController.money >= increaseIncomePrice) {
            ActivateButton(increaseIncomeButton);
        } else {
            DeactivateButton(increaseIncomeButton);
        }
    }
}
