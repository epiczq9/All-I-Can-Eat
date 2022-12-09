using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTrigger : MonoBehaviour
{
    public GameController gameController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        //gameController.foodGroup = other.gameObject.GetComponent<RandomFood>().foodGroupOnTray;
    }
}
