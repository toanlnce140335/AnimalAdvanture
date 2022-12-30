using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetHighScore : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        int lv = SceneManager.GetActiveScene().buildIndex - 2;
        highScoreText.text = PlayerPrefs.GetInt("highScore" + lv).ToString();
    }
}
