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

    public Text mergePriceText;
    public Text addFoodText;
    public Text addFoodPriceText;
    public Text increaseSpeedPriceText;
    public Text increaseIncomePriceText;

    public Image foodImage;
    public Sprite hotdogImg;
    public Sprite tacoImg;
    public Sprite ramenImg;

    public float timeScaleMultiplier = 1.3f;

    public bool mergeOnCooldown = false;

    void Start() {
        gameController = GameObject.FindGameObjectWithTag("Woman").GetComponent<GameController>();
        UpdateText();
    }


    void Update() {
        /*if (mergeOnCooldown) {
            if (mergeCooldownCurrent < mergeCooldownMax) {
                mergeCooldownCurrent += Time.deltaTime;
                Debug.Log("MERGE ON COOLDOWN");
            } else {
                mergeOnCooldown = false;
                mergeCooldownCurrent = 0;
            }
        }*/
    }

    public void Merge() {
        mergeOnCooldown = true;
        gameController.ActivateBothHands();
        gameController.money -= mergePrice;
        mergePrice = (int)(mergePrice * 1.2f);
        UpdateText();
    }


    public void AddFood() {
        foodManager.AddFood();
        gameController.money -= addFoodPrice;
        addFoodPrice = (int)(addFoodPrice * 1.5f);
        UpdateText();
    }

    public void IncreaseSpeed() {
        Time.timeScale *= timeScaleMultiplier;
        gameController.money -= increaseSpeedPrice;
        increaseSpeedPrice = (int)(increaseSpeedPrice * 2f);
        UpdateText();
    }

    public void IncreaseIncome() {
        foodManager.foodWorthMod *= 1.2f;
        gameController.money -= increaseIncomePrice;
        increaseIncomePrice = (int)(increaseIncomePrice * 2f);
        UpdateText();
    }

    void UpdateText() {
        //FakeUpdateForCreatives();

        gameController.UpdateText();
        mergePriceText.text = mergePrice.ToString();

        if (!foodManager.hotdogAdded) {
            addFoodText.text = "ADD HOT DOGS";
            foodImage.sprite = hotdogImg;
        } else if (!foodManager.tacosAdded) {
            addFoodText.text = "ADD TACOS";
            foodImage.sprite = tacoImg;
        } else if (!foodManager.ramenAdded) {
            addFoodText.text = "ADD RAMEN";
            foodImage.sprite = ramenImg;
        } else {
            addFoodText.text = "NO MORE FOOD";
            Destroy(foodImage);
        }

        if (foodManager.finalFoodAdded) {
            addFoodPriceText.text = "";
        } else {
            addFoodPriceText.text = addFoodPrice.ToString();
        }
        
        increaseSpeedPriceText.text = increaseSpeedPrice.ToString();
        increaseIncomePriceText.text = increaseIncomePrice.ToString();

    }

    void FakeUpdateForCreatives() {
        foodManager.hotdogAdded = true;
        foodManager.tacosAdded = true;
        foodManager.ramenAdded = true;
        foodManager.finalFoodAdded = true;

    }
}
