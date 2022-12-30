using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleFinishItem : MonoBehaviour
{
    [SerializeField] public GameObject enemyBoss;
    [SerializeField] public GameObject finishItem;

    void Start()
    {
        finishItem.SetActive(false);
    }

    void Update()
    {
        if(enemyBoss != null)
        {
            Debug.Log("1");
            finishItem.SetActive(false);
        }
        else
        {
            Debug.Log("0");
            finishItem.SetActive(true);
        }
    }
}
