using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaterBehaviour : MonoBehaviour
{
    public GameController gameCont;
    void Start() {
        
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            GetComponent<Animator>().Play("LeftHandEat");
        }

        if (Input.GetButtonDown("Fire2")) {
            GetComponent<Animator>().Play("RightHandEat");
        }

        if (Input.GetButtonDown("Fire3")) {
            GetComponent<Animator>().Play("BothHandsEat");
        }
        
        if (Input.GetButtonDown("Jump")) {
            //GetComponent<Animator>().Play("HappyEat");
        }
    }
}
