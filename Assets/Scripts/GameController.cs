using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Actopolus.FakeLeaderboard.Src;
using Timers;

public class GameController : MonoBehaviour
{
    private const string burgerString = "Burger";
    private const string hotdogString = "HotDog";
    private const string tacoString = "Taco";
    public GameObject food;
    public GameObject foodGroup;
    public List<GameObject> foods;

    public GameObject tripleBurgerPrefab;
    public GameObject tripleHotDogPrefab;
    public GameObject tripleTacoPrefab;
    public GameObject tripleRamenPrefab;

    bool leaderboardHidden = true;
    bool gotFood = false;
    //bool doneEating = false;
    public bool useBothHands = false;
    bool isLeftNext = true;
    public bool timerRanOut = false;

    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject bothHands;
    public GameObject ramenHand;
    public GameObject head;

    Color currentFaceColor;
    public Color greenFaceColor;

    float timerStartEatingLength = 0.35f;
    
    bool spedUp = false;
    float tapTimerCurrent = 0;
    readonly float tapTimerMax = 1f;

    float tick = 0f;
    bool changeColor = false;

    public float money = 0;
    public Text moneyText;

    public GameObject crumbs;
    public GameObject drops;
    public GameObject wipeCrumbs;
    public Transform mouthTransform;

    public TrayMove trayMove;
    public RandomFood randomFood;
    Animator animator;
    SceneManagment sceneMng;
    public ButtonBehaviour buttonBehaviour;
    public GameObject canvasUI;


    void Start() {
        currentFaceColor = head.GetComponent<Renderer>().material.color;
        animator = GetComponent<Animator>();
        sceneMng = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagment>();
        moneyText.text = money.ToString();
        //Time.timeScale *= 3;
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
            //ActivateBothHands();
            Leaderboard.Instance.Reset();
        }

        if (spedUp) {
            if (tapTimerCurrent < tapTimerMax) {
                tapTimerCurrent += Time.deltaTime;
            } else {
                spedUp = false;
                SlowDownAnimations();
            }
        }

        if (changeColor) {
            if (head.GetComponent<Renderer>().material.color != greenFaceColor) {
                tick += Time.deltaTime / 2;
                head.GetComponent<Renderer>().material.color = Color.Lerp(currentFaceColor, greenFaceColor, tick);
            }
        }
    }

    void SetupFoodList() {
        foreach(Transform foodItem in foodGroup.transform) {
            foods.Add(foodItem.gameObject);
        }
    }

    public void BeginEating() {
        SetupFoodList();
        if (foods[0].CompareTag("Ramen")) {
            animator.Play("EatRamen");
        } else if (foods[0].CompareTag("Bljak")) {
            animator.Play("BadFood");
        } else {
            animator.Play("LeftHandEat");
        }
        
    }

    /*public void StartLeftEating() {                                             //Called in animation
        Debug.Log("Starting Left Anim");
        //TimersManager.SetTimer(this, timerStartEatingLength, GetFoodLeft);
    }

    public void StartRightEating() {                                             //Called in animation
        Debug.Log("Starting Right Anim");
        TimersManager.SetTimer(this, timerStartEatingLength, GetFoodRight);
    }

    public void StartBothEating() {                                              //Called in animation
        TimersManager.SetTimer(this, timerStartEatingLength, GetFoodBoth);
    }*/

    public void SpeedUpAnimations() {
        animator.speed = 2f;
        timerStartEatingLength /= 2;
    }

    public void SlowDownAnimations() {
        animator.speed = 1f;
        timerStartEatingLength *= 3;
    }

    public void GetFoodLeft() {                                              //Called in animation
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

    public void GetFoodRight() {                                              //Called in animation
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

    public void GetFoodBoth() {                                              //Called in animation
        if (!gotFood && foods.Count >= 3) {
            switch (foods[0].tag) {
                case burgerString:
                    food = Instantiate(tripleBurgerPrefab, leftHand.transform);
                    break;
                case hotdogString:
                    food = Instantiate(tripleHotDogPrefab, leftHand.transform);
                    break;
                case tacoString:
                    food = Instantiate(tripleTacoPrefab, leftHand.transform);
                    break;
                default:
                    break;
            }
            //food = Instantiate(tripleBurgerPrefab, leftHand.transform);
            for(int i = 0; i < 3; i++) {
                Destroy(foods[0]);
                foods.Remove(foods[0]);
            }
            gotFood = true;
        }
    }

    public void GetRamen() {                                                   //Called in animation
        if (!gotFood) {
            if (foods.Count != 0) {
                food = foods[0];
                foods.Remove(foods[0]);
                ChangeTransform(food, ramenHand);
                food.transform.parent = ramenHand.transform;
                gotFood = true;
            }
        }
    }

    public void GetRamenMerge() {                                                   //Called in animation
        if (!gotFood && foods.Count >= 3) {
            food = Instantiate(tripleRamenPrefab, ramenHand.transform);
            for (int i = 0; i < 3; i++) {
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

    public void Eat() {                                                        //Called in animation
        food.GetComponent<FoodEaten>().TakeABite();
        Instantiate(crumbs, mouthTransform);
    }

    public void TiltRamenBowl() {                                                   //Called in animation
        food.GetComponent<RamenEaten>().TiltBowl();
    }

    public void TiltRamenBowlBack() {                                                   //Called in animation
        food.GetComponent<RamenEaten>().TiltBackBowl();
    }

    public void EatRamen() {                                                   //Called in animation
        food.GetComponent<RamenEaten>().Eat();
        Instantiate(drops, mouthTransform);
    }

    public void EatBadFood() {                                                   //Called in animation
        food.GetComponent<FoodEaten>().TakeABite();
        TimersManager.SetTimer(this, 0.7f, TurnGreen);
    }

    void TurnGreen() {
        changeColor = true;
    }

    public void DropBadFood() {                                                   //Called in animation
        food.transform.parent = null;
        food.transform.DOMoveY(0.5f, 0.7f);
    }

    public void DropBowl() {                                                   //Called in animation
        food.GetComponent<RamenEaten>().DropBowl();
        food.transform.parent = null;
    }

    public void DropBowlMerge() {                                                   //Called in animation
        food.transform.parent = null;
        food.GetComponent<RamenEaten>().DropBowlMerge();
        
    }

    public void WipeFace() {                                                   //Called in animation
        Instantiate(wipeCrumbs, mouthTransform);
    }

    public void FinishedEating() {                                             //Called in animation
        UpdateText();
        food = null;
        gotFood = false;
        isLeftNext = !isLeftNext;
        if (timerRanOut) {
            SlowDownAnimations();
            //animator.SetBool("foodGone", true);
            animator.Play("FinishedEating");
        } else {
            if (foods.Count != 0) {
                if (useBothHands) {
                    animator.Play("BothHandsEat");
                    useBothHands = false;
                } else {
                    if (isLeftNext) {
                        buttonBehaviour.mergeOnCooldown = false;
                        animator.Play("LeftHandEat");
                    } else {
                        buttonBehaviour.mergeOnCooldown = false;
                        animator.Play("RightHandEat");
                    }
                }
            } else if (trayMove.currentTray < trayMove.trayList.Count) {
                animator.Play("WipeFace");
                trayMove.MoveTrays();
            } else {
                SlowDownAnimations();
                //animator.SetBool("foodGone", true);
                animator.Play("FinishedEating");
            }
        }
    }

    public void FinishedEatingRamen() {                                             //Called in animation
        UpdateText();
        food = null;
        gotFood = false;
        isLeftNext = !isLeftNext;
        if (foods.Count != 0) {
            if (useBothHands) {
                animator.Play("EatRamenMerge");
                useBothHands = false;
            } else {
                buttonBehaviour.mergeOnCooldown = false;
                animator.Play("EatRamen");
            }
        } else if (trayMove.currentTray < trayMove.trayList.Count) {
            animator.Play("WipeFace");
            trayMove.MoveTrays();
        } else {
            SlowDownAnimations();
            //animator.SetBool("foodGone", true);
            animator.Play("FinishedEating");
        }
    }

    public void FinishedEatingBadFood() {                                             //Called in animation
        UpdateText();
        food = null;
        gotFood = false;
        animator.enabled = false;
        ActivateLeaderboard();
    }

    public void UpdateText() {
        moneyText.text = money.ToString();
    }

    public void ActivateLeaderboard() {                                                   //Called in animation
        if (leaderboardHidden) {
            ShowLeaderboard();
        } else {
            HideLeaderboard();
        }
    }

    void ShowLeaderboard() {
        canvasUI.SetActive(false);
        Leaderboard.Instance.Show();
        leaderboardHidden = false;
        //TimersManager.SetTimer(this, 5f, HideLeaderboard);
    }

    void HideLeaderboard() {
        Leaderboard.Instance.Hide(LoadNextScene);
        leaderboardHidden = true;
    }

    void ResetScene() {
        sceneMng.LoadScene(0);
    }

    public void LoadNextScene() {
        sceneMng.LoadScene(1);
    }

}
