using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour
{
    private int cherries = 0;
    public int totalCherry = 0;
    public int coin = 0;
    public GameObject[] stars;
    [SerializeField] private Text cherriesText;
    [SerializeField] private Text highScoreText;
    public TextMeshProUGUI textCoins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            cherries++;
            cherriesText.text = cherries + "";            
        }else if (collision.gameObject.CompareTag("Finish"))
        {
            ShowStarRating();
            int lv = SceneManager.GetActiveScene().buildIndex - 2;            
            highScoreText.text = PlayerPrefs.GetInt("highScore" + lv).ToString();
        }else if (collision.transform.tag == "coin")
        {
            coin++;
            textCoins.text = coin.ToString();
        }
    }

    public void MenuOnClick()
    {
        LoadingScene.instance.ChangSceneOnClick(2);
        Time.timeScale = 1;
    }

    public void NextLevelOnClick()
    {
        LoadingScene.instance.ChangSceneOnClick(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void ShowStarRating()
    {        
        float f_cherries = float.Parse(cherriesText.text);
        float f_totalCherry = (float)totalCherry;
        float percenttage = (f_cherries / f_totalCherry) * 100f;

        int starCount = 0;
        int highStar = 0;
        int highScore = 0;
        int level = SceneManager.GetActiveScene().buildIndex - 2;

        if (percenttage >= 1f && percenttage < 30)
        {
            //one star
            stars[1].SetActive(true);
            starCount = 1;
        }
        else if (percenttage >= 30 && percenttage < 65) 
        {
            //two Stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            starCount = 2;
        }
        else if (percenttage >= 65) 
        {
            //three Stars
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            starCount = 3;
        }
        else
        {
            stars[0].SetActive(false);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
            starCount = 0;
        }
        
        if (percenttage >= 1f)
        {
            
            highStar = PlayerPrefs.GetInt("Level" + level, highStar);
            if (starCount > highStar)
            {
                highStar = starCount;                
                PlayerPrefs.SetInt("Level" + level, highStar);
                PlayerPrefs.Save();
            }            
        }
        highScore = PlayerPrefs.GetInt("highScore" + level, highScore);
        if (cherries > highScore)
        {
            highScore = cherries;
            PlayerPrefs.SetInt("highScore" + level, highScore);
            PlayerPrefs.Save();
        }
    }
}
