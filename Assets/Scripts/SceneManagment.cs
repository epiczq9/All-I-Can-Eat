using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{

    void Start() {
        
    }

    void Update() {
        
    }

    public void LoadScene(int level) {
        SceneManager.LoadScene(level);
    }
}
