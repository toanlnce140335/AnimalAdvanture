using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private int retryCoin = 5;
    private int retryIncreaseCoin = 5;
    private int cherries = 0;
    [SerializeField] private Text cherriesText;
    [SerializeField] private Text retryCoinText;
    [SerializeField] private PlayerManager player;

    private void OnEnable()
    {
        retryCoinText.text = "CONTINUE (" + retryCoin + " COINS)";
    }

    public void Retry()
    {
        if (ScoreHandler.instance.Coins >= retryCoin)
        {
            ScoreHandler.instance.Coins -= retryCoin;
            retryCoin += retryIncreaseCoin;
            player.Retry();
            transform.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        //LoadingScene.instance.ChangSceneOnClick(2);
        SceneManager.LoadScene("LevelScene");
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            cherries++;
            cherriesText.text = cherries + "";
        }
    }
}
