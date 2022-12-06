using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Actopolus.FakeLeaderboard.Src;

public class GameController : MonoBehaviour
{
    GameObject food;
    public List<GameObject> foods;
    bool leaderboardHidden = true;
    void Start() {
        
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            if(food != null) {
                food.GetComponent<FoodEaten>().TakeABite();
            }
        }

        if (Input.GetButtonDown("Fire2")) {
            GetFood();
        }

        if (Input.GetButtonDown("Jump")) {
            if (leaderboardHidden) {
                ShowLeaderboard();
            } else {
                HideLeaderboard();
            }
        }
    }

    public void GetFood() {
        //food = GameObject.FindGameObjectWithTag("Food");
        if(foods.Count == 0) {
            ShowLeaderboard();
        } else {
            food = foods[0];
            foods.Remove(foods[0]);
            food.transform.DOMoveY(1f, 0.5f);
        }
    }

    public void ShowLeaderboard() {
        Leaderboard.Instance.Show();
        leaderboardHidden = false;
    }

    public void HideLeaderboard() {
        Leaderboard.Instance.Hide();
        leaderboardHidden = true;
    }


}
