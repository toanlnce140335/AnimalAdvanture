using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetPopup : MonoBehaviour
{
    [SerializeField] GameObject resetPanel;
    
    public void ResetBtnOnClick()
    {
        resetPanel.SetActive(true);
    }

    public void onUserClickYesNo(int choice)
    //no = 0 yes = 1
    {
        if (choice == 1)
        {
            ResetOnClick();            
        }
        else
        {
            resetPanel.SetActive(false);
        }
        resetPanel.SetActive(false); //else
    }
    public void ResetOnClick()
    {
        PlayerPrefs.DeleteAll();
    }
}
