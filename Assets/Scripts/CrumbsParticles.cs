using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class CrumbsParticles : MonoBehaviour
{

    void Start() {
        TimersManager.SetTimer(this, 0.5f, DestroyItself);
    }

    void DestroyItself() {
        Destroy(gameObject);
    }
}
