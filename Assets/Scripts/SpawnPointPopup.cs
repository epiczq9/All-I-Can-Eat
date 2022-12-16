using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnPointPopup : MonoBehaviour
{
    GameController gameController;
    int points;
    public GameObject pointsPopUpPrefab;
    
    public void SpawnPoints(int points) {
        GameObject popup = Instantiate(pointsPopUpPrefab, transform);
        popup.GetComponent<TMP_Text>().text = "+ " + points.ToString();
    }
}
