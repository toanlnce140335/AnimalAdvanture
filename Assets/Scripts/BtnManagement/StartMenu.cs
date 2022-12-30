using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private int menuScene;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void inGame(int sceneID)
    {
        PlayerPrefs.SetInt("SavedScene", menuScene);
        SceneManager.LoadScene(sceneID);
    }
}
