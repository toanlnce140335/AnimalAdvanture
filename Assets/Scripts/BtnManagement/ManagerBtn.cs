using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerBtn : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    //StartMenu
    private int menuScene;
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        UnityEngine.Application.Quit();
    }

    public void inGame(int sceneID)
    {
        PlayerPrefs.SetInt("SavedScene", menuScene);
        SceneManager.LoadScene(sceneID);
    }

    //PauseMenu
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resumne()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelScene");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //FinishGame
    public void MenuOnClick()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void NextLevelOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //EndGame
    //public void Quit()
    //{
    //    SceneManager.LoadScene("LevelScreen");
    //}
}
