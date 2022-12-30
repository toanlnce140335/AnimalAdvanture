using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    public GameFinish gameFinish;
    private CoinPicker coinPicker;
    private ScoreHandler scoreHandler;
    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        coinPicker = GameObject.FindObjectOfType<CoinPicker>();
        scoreHandler = GameObject.FindObjectOfType<ScoreHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            scoreHandler.Coins += coinPicker.Coin;
            levelCompleted = true;
            LoadGameFinish();
        }
    }
    private void LoadGameFinish()
    {
        Time.timeScale = 0;
        gameFinish.gameObject.SetActive(true);
    }
}
