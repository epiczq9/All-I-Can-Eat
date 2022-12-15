using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class CrumbsParticles : MonoBehaviour
{

    void Start() {
        TimersManager.SetTimer(this, 2f, DestroyItself);
    }

    void DestroyItself() {
        Destroy(gameObject);
    }
}
