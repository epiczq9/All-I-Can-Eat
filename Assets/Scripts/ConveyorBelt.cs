using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void StartAnimation() {
        animator.enabled = true;
    }
    public void StopAnimation() {
        animator.enabled = false;
    }
}
