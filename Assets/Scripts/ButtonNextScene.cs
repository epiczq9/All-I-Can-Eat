using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNextScene : MonoBehaviour
{
    SceneManagment sceneMngr;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void LoadNextScene() {
        sceneMngr.LoadScene();
    }
}
