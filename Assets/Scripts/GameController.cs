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
    bool gotFood = false;
    SceneManagment sceneMng;
    void Start() {
        sceneMng = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagment>();
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            if(food != null) {
                food.GetComponent<FoodEaten>().TakeABite();
            }
        }

        if (Input.GetButtonDown("Fire2")) {
            if (!gotFood) {
                GetFood();
            }
        }

        if (Input.GetButtonDown("Jump")) {
            Leaderboard.Instance.Reset();
            ActivateLeaderboard();
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
            gotFood = true;
        }
    }

    public void ActivateLeaderboard() {
        if (leaderboardHidden) {
            ShowLeaderboard();
        } else {
            HideLeaderboard();
        }
    }
    void ShowLeaderboard() {
        Leaderboard.Instance.Show();
        leaderboardHidden = false;
    }

    void HideLeaderboard() {
        Leaderboard.Instance.Hide(ResetScene);
        leaderboardHidden = true;
    }

    public void FinishedFood() {
        gotFood = false;
        if (foods.Count == 0) {
            ActivateLeaderboard();
        }
    }

    void ResetScene() {
        sceneMng.LoadScene(0);
    }


}
