using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RequestPopup : MonoBehaviour
{
    [SerializeField] GameObject requestPanel;

    public void ResetBtnOnClick()
    {
        requestPanel.SetActive(true);
    }

    public void onUserClickYesNo(int choice)
    //no = 0 yes = 1
    {
        if (choice == 1)
        {
            LoadShopScene();
        }
        else
        {
            requestPanel.SetActive(false);
        }
        requestPanel.SetActive(false); //else
    }

    public void LoadShopScene()
    {
        LoadingScene.instance.ChangSceneOnClick(20);
        //SceneManager.LoadScene("ShopScene");
    }
}
