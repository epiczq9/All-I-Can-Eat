using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetup : MonoBehaviour
{
    public GameController gameController;

    ButtonBehaviour buttonBehaviour;
    FoodManager foodManager;
    TrayMove trayMove;

    public GameObject mergeButton;
    public GameObject addFoodButton;
    public GameObject increaseSpeedButton;
    public GameObject increaseIncomeButton;
    public Image foodImage;

    void Start() {
        foodManager = GameObject.FindGameObjectWithTag("FoodManager").GetComponent<FoodManager>();
        trayMove = GameObject.FindGameObjectWithTag("FoodManager").GetComponent<TrayMove>();
        buttonBehaviour = GetComponent<ButtonBehaviour>();
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
        if (!gameController.useBothHands && trayMove.trayReady && gameController.money >= buttonBehaviour.mergePrice && gameController.foods.Count >= 3) {
            ActivateButton(mergeButton);
        } else {
            DeactivateButton(mergeButton);
        }
    }

    void SetupAddFoodButton() {
        if(foodImage != null) {
            if (addFoodButton.GetComponent<Button>().IsInteractable()) {
                foodImage.color = new Color(1, 1, 1, 1f);
            } else {
                foodImage.color = new Color(0.9f, 0.9f, 0.9f, 0.4f);
            }   
        }
        if (trayMove.trayReady && gameController.money >= buttonBehaviour.addFoodPrice && !foodManager.finalFoodAdded) {
            ActivateButton(addFoodButton);
        } else {
            DeactivateButton(addFoodButton);
        }
    }

    void SetupIncreaseSpeedButton() {
        if (trayMove.trayReady && gameController.money >= buttonBehaviour.increaseSpeedPrice) {
            ActivateButton(increaseSpeedButton);
        } else {
            DeactivateButton(increaseSpeedButton);
        }
    }

    void SetupIncreaseIncomeButton() {
        if (trayMove.trayReady && gameController.money >= buttonBehaviour.increaseIncomePrice) {
            ActivateButton(increaseIncomeButton);
        } else {
            DeactivateButton(increaseIncomeButton);
        }
    }
}
