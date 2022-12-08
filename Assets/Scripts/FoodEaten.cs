using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEaten : MonoBehaviour
{
    public GameObject wholeFood;
    public GameObject halfFood;
    bool halfEaten = false;
    public float worth;

    GameController eater;

    private void Start() {
        eater = GameObject.FindGameObjectWithTag("Woman").GetComponent<GameController>();
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
        eater.money += worth;
        Destroy(gameObject);
        //gameController.FinishedFood();
    }    
}
