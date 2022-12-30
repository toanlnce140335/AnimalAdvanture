using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public GameObject LevelDialog;
    public Text LevelStatus;
    public Text scoreText;

    public static UIHandler instance;

    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void ShowLevelDialog(string status, string score)
    {
        GetComponent<StarHandler>().starsAchived();
        LevelDialog.SetActive(true);
        LevelStatus.text = status;
        scoreText.text = score;
    }
}
