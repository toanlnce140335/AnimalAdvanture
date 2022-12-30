using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    [SerializeField] GameObject exitPanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                if (exitPanel)
                {
                    exitPanel.SetActive(true);
                }
            }
        }
    }
    public void onUserClickYesNo(int choice)
    //no = 0 yes = 1
    {
        if (choice == 1)
        {
            UnityEngine.Application.Quit();
        }
        exitPanel.SetActive(false); //else
    }
    public void Quit() //load popup
    {
        exitPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
