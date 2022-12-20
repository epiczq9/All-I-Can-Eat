using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Timers;

public class UITimer : MonoBehaviour
{
    GameController gameController;
    int time;
    float timerCurrentInt;
    public float timerMax = 120;
    public bool timerRanOut = false;


    void Start() {
        //TimersManager.SetTimer(this, timerMax, Finish);
        gameController = GameObject.FindGameObjectWithTag("Woman").GetComponent<GameController>();
    }

    void Update() {
        if (Input.GetButtonDown("Fire2")) {
            Finish();
        }
        //time = (int)TimersManager.RemainingTime(Finish);
        //GetComponent<Text>().text = StylizeTimerWithManager();

        TimerWithoutManager();
        //GetComponent<Text>().text = StylizeTimerWithoutManager();
    }

    void TimerWithoutManager() {
        if (timerMax > 0) {
            timerMax -= Time.deltaTime / Time.timeScale;
        } else {
            //Finish();
        }
        timerCurrentInt = (int)timerMax;
    }

    string StylizeTimerWithManager() {
        if (timerRanOut) {
            return "00:00";
        } else {
            if ((time % 60) < 10) {
                return "0" + (int)(time / 60) + ":0" + time % 60;
            } else {
                return "0" + (int)(time / 60) + ":" + time % 60;
            }
        }
    }

    string StylizeTimerWithoutManager() {
        if (timerRanOut) {
            return "00:00";
        } else {
            if ((timerCurrentInt % 60) < 10) {
                return "0" + (int)(timerCurrentInt / 60) + ":0" + timerCurrentInt % 60;
            } else {
                return "0" + (int)(timerCurrentInt / 60) + ":" + timerCurrentInt % 60;
            }
        }
    }

    void Finish() {
        timerRanOut = true;
        gameController.timerRanOut = true;
    }
}
