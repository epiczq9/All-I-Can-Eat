using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEaten : MonoBehaviour
{
    public GameObject wholeFood;
    public GameObject halfFood;
    bool halfEaten = false;

    GameController gameController;

    private void Start() {
        gameController = GameObject.FindGameObjectWithTag("Woman").GetComponent<GameController>();
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
        Destroy(gameObject);
        //gameController.FinishedFood();
    }    
}
