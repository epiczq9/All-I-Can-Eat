using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Timers;

public class UITimer : MonoBehaviour
{
    GameController gameController;
    int time;
    public int timerMax = 30;
    public bool timerRanOut = false;


    void Start() {
        TimersManager.SetTimer(this, timerMax, Finish);
        gameController = GameObject.FindGameObjectWithTag("Woman").GetComponent<GameController>();
    }

    void Update() {
        time = (int)TimersManager.RemainingTime(Finish);
        
        GetComponent<Text>().text = StylizeTimer();
    }

    string StylizeTimer() {
        if (timerRanOut) {
            return "00:00";
        } else {
            if ((time % 60) < 10) {
                return "0" + time / 60 + ":0" + time % 60;
            } else {
                return "0" + time / 60 + ":" + time % 60;
            }
        }

    }

    void Finish() {
        timerRanOut = true;
        gameController.timerRanOut = true;
    }
}
