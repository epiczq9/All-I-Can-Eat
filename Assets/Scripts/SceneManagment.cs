using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public int nextLevel;

    void Start() {
        
    }

    void Update() {
        
    }
    public void LoadScene() {
        SceneManager.LoadScene(nextLevel);
    }

    public void LoadScene(int level) {
        SceneManager.LoadScene(level);
    }
}
