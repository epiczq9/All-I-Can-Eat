using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RamenEaten : MonoBehaviour
{
    public GameObject fullBowl;
    public GameObject emptyBowl;
    public float worth;
    public float worthMod = 1;

    public Transform overheadTransform;
    public Transform dropTransform;

    GameController eater;
    public FoodManager foodManager;

    private void Start() {
        overheadTransform = GameObject.FindGameObjectWithTag("OverheadTransform").GetComponent<Transform>();
        dropTransform = GameObject.FindGameObjectWithTag("DropTransform").GetComponent<Transform>();
        eater = GameObject.FindGameObjectWithTag("Woman").GetComponent<GameController>();
        foodManager = GameObject.FindGameObjectWithTag("FoodManager").GetComponent<FoodManager>();
    }
    public void Eat() {
        eater.money += (int)(worth * foodManager.foodWorthMod);
        emptyBowl.SetActive(true);
        fullBowl.SetActive(false);
    }

    public void TiltBowl() {
        transform.DORotate(new Vector3(-22.212f, 0.902f, -1.187f), 0.3f);
    }

    public void TiltBackBowl() {
        transform.DORotate(Vector3.zero, 0.3f);
    }

    public void DropBowl() {
        Sequence dropSequence = DOTween.Sequence();
        dropSequence.Append(transform.DORotate(new Vector3(0, 0, 75), 0.3f));
        dropSequence.Join(transform.DOMoveY(0.4f, 0.5f)).OnComplete(DestroyItself);
    }

    public void DropBowlMerge() {
        Sequence dropSequence = DOTween.Sequence();
        dropSequence.Append(transform.DORotate(new Vector3(-50, 0, 0), 0.3f));
        dropSequence.Join(transform.DOMove(overheadTransform.position, 0.2f));
        dropSequence.Append(transform.DOMove(dropTransform.position, 0.3f)).OnComplete(DestroyItself);
    }
    

    private void DestroyItself() {
        Destroy(gameObject);
    }
}
