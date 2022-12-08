using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Actopolus.FakeLeaderboard.Src;
using Timers;

public class GameController : MonoBehaviour
{
    public GameObject food;
    public List<GameObject> foods;
    public GameObject burgerPrefab;
    public GameObject tripleBurgerPrefab;
    bool leaderboardHidden = true;
    bool gotFood = false;
    //bool doneEating = false;
    public bool useBothHands = false;
    bool isLeftNext = false;

    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject bothHands;

    float timerStartEatingLength = 0.35f;
    
    bool spedUp = false;
    float tapTimerCurrent = 0;
    readonly float tapTimerMax = 1f;

    Animator animator;
    SceneManagment sceneMng;
    void Start() {
        animator = GetComponent<Animator>();
        sceneMng = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagment>();
    }

    void Update() {
        if (Input.GetButtonDown("Fire1") && foods.Count != 0) {
            tapTimerCurrent = 0;
            if (!spedUp) {
                spedUp = true;
                SpeedUpAnimations();
            }
        }
        if (Input.GetButtonDown("Fire2")) {

        }
        if (Input.GetButtonDown("Fire3")) {
            
        }
        if (Input.GetButtonDown("Jump")) {
            ActivateBothHands();
        }

        if (spedUp) {
            if (tapTimerCurrent < tapTimerMax) {
                tapTimerCurrent += Time.deltaTime;
            } else {
                spedUp = false;
                SlowDownAnimations();
            }
        }
    }

    public void StartLeftEating() {
        TimersManager.SetTimer(this, timerStartEatingLength, GetFoodLeft);
    }

    public void StartRightEating() {
        TimersManager.SetTimer(this, timerStartEatingLength, GetFoodRight);
    }

    public void StartBothEating() {
        TimersManager.SetTimer(this, timerStartEatingLength, GetFoodBoth);
    }

    public void SpeedUpAnimations() {
        animator.speed = 3f;
        timerStartEatingLength /= 3;
    }

    public void SlowDownAnimations() {
        animator.speed = 1f;
        timerStartEatingLength *= 3;
    }

    public void GetFoodLeft() {
        if (!gotFood) {
            if (foods.Count != 0) {
                food = foods[0];
                foods.Remove(foods[0]);
                ChangeTransform(food, leftHand);
                food.transform.parent = leftHand.transform;
                gotFood = true;
            }
        }
    }

    public void GetFoodRight() {
        if (!gotFood) {
            if (foods.Count != 0) {
                food = foods[0];
                foods.Remove(foods[0]);
                ChangeTransform(food, rightHand);
                food.transform.parent = rightHand.transform;
                gotFood = true;
            }
        }
    }

    public void GetFoodBoth() {
        if (!gotFood && foods.Count >= 3) {
            food = Instantiate(tripleBurgerPrefab, leftHand.transform);
            for(int i = 0; i < 3; i++) {
                Destroy(foods[0]);
                foods.Remove(foods[0]);
            }
            gotFood = true;
            
        }
    }
    public void ChangeTransform(GameObject obj, GameObject target) {
        obj.transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
    }

    public void ActivateBothHands() {
        if(foods.Count >= 3) {
            useBothHands = true;
        }
    }

    public void LeftFinished() {    //Called in animation
        food = null;
        gotFood = false;
        if (foods.Count != 0) {
            if (useBothHands) {
                animator.Play("BothHandsEat");
                useBothHands = false;
                isLeftNext = false;
            } else {
                animator.Play("RightHandEat");
            }
        } else {
            SlowDownAnimations();
            GetComponent<Animator>().SetBool("foodGone", true);
        }
    }

    public void RightFinished() {    //Called in animation
        food = null;
        gotFood = false;
        if (foods.Count != 0) {
            if (useBothHands) {
                animator.Play("BothHandsEat");
                useBothHands = false;
                isLeftNext = true;
            } else {
                animator.Play("LeftHandEat");
            }
        } else {
            SlowDownAnimations();
            GetComponent<Animator>().SetBool("foodGone", true);
        }
    }

    public void BothFinished() {    //Called in animation
        food = null;
        gotFood = false;
        if (foods.Count != 0) {
            if (useBothHands) {
                animator.Play("BothHandsEat");
                useBothHands = false;
                isLeftNext = !isLeftNext;
            } else {
                if (isLeftNext) {
                    animator.Play("LeftHandEat");
                } else {
                    animator.Play("RightHandEat");
                }
            }
        } else {
            SlowDownAnimations();
            GetComponent<Animator>().SetBool("foodGone", true);
        }
    }

    public void Eat() {    //Called in animation
        food.GetComponent<FoodEaten>().TakeABite();
    }
    public void FinishedFood() {
        food = null;
        gotFood = false;
        if (foods.Count == 0) {
            SlowDownAnimations();
            GetComponent<Animator>().SetBool("foodGone", true);
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
        TimersManager.SetTimer(this, 5f, HideLeaderboard);
    }
    void HideLeaderboard() {
        Leaderboard.Instance.Hide(ResetScene);
        leaderboardHidden = true;
    }

    void ResetScene() {
        sceneMng.LoadScene(0);
    }

    public void FinishedEating() {
        food = null;
        gotFood = false;
        if (foods.Count != 0) {
            if (useBothHands) {
                animator.Play("BothHandsEat");
                useBothHands = false;
                isLeftNext = !isLeftNext;
            } else {
                if (isLeftNext) {
                    animator.Play("LeftHandEat");
                } else {
                    animator.Play("RightHandEat");
                }
            }
        } else {
            SlowDownAnimations();
            GetComponent<Animator>().SetBool("foodGone", true);
        }
    }


}
