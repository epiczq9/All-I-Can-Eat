using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;
using DG.Tweening;
using TMPro;

public class FloatingText : MonoBehaviour {

    float timerCurrent = 0;
    float timerMax = 2f;

    void Start() {
        TimersManager.SetTimer(this, 0.5f, DestroyText);
        transform.DOMoveY(1.7f, 0.5f);
    }

    private void Update() {
        
    }

    private void LateUpdate() {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }

    void DestroyText() {
        Destroy(gameObject);
    }

}
