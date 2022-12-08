using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Actopolus.FakeLeaderboard.Src;
using Timers;

public class GameController : MonoBehaviour
{
    public GameObject food;
    public Transform foodGroup;
    public List<GameObject> foods;

    public GameObject tripleHotDogPrefab;
    public GameObject tripleBurgerPrefab;
    bool leaderboardHidden = true;
    bool gotFood = false;
    //bool doneEating = false;
    public bool useBothHands = false;
    bool isLeftNext = true;

    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject bothHands;

    float timerStartEatingLength = 0.35f;
    
    bool spedUp = false;
    float tapTimerCurrent = 0;
    readonly float tapTimerMax = 1f;

    public float money = 0;
    public Text moneyText;
    float reward = 0;

    Animator animator;
    SceneManagment sceneMng;
    void Start() {
        SetupFoodList();
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

    void SetupFoodList() {
        foreach(Transform foodItem in foodGroup) {
            foods.Add(foodItem.gameObject);
        }
    }

    public void StartLeftEating() {                                             //Called in animation
        TimersManager.SetTimer(this, timerStartEatingLength, GetFoodLeft);
    }

    public void StartRightEating() {                                             //Called in animation
        TimersManager.SetTimer(this, timerStartEatingLength, GetFoodRight);
    }

    public void StartBothEating() {                                              //Called in animation
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

    public void FinishedEating() {                                             //Called in animation
        moneyText.text = "$" + money.ToString();
        food = null;
        gotFood = false;
        isLeftNext = !isLeftNext;
        if (foods.Count != 0) {
            if (useBothHands) {
                animator.Play("BothHandsEat");
                useBothHands = false;
            } else {
                if (isLeftNext) {
                    animator.Play("LeftHandEat");
                } else {
                    animator.Play("RightHandEat");
                }
            }
        } else {
            SlowDownAnimations();
            //animator.SetBool("foodGone", true);
            animator.Play("FinishedEating");
        }
    }

    public void Eat() {                                                        //Called in animation
        food.GetComponent<FoodEaten>().TakeABite();
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

}
