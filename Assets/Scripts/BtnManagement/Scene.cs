using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void LoadStartScene()
    {
        LoadingScene.instance.ChangSceneOnClick(0);
        //SceneManager.LoadScene("StartScene");
    }

    public void LoadEndScene()
    {
        LoadingScene.instance.ChangSceneOnClick(15);
        //SceneManager.LoadScene("EndScene");
    }

    public void LoadCharacterScene()
    {
        LoadingScene.instance.ChangSceneOnClick(1);
        //SceneManager.LoadScene("CharacterSelected");
    }

    public void LoadLanguageScene()
    {
        LoadingScene.instance.ChangSceneOnClick(16);
        //SceneManager.LoadScene("LanguageScene");
    }
    public void LoadInfoScene()
    {
        LoadingScene.instance.ChangSceneOnClick(17);
        //SceneManager.LoadScene("InfoScene");
    }
    public void LoadCreditsScene()
    {
        LoadingScene.instance.ChangSceneOnClick(18);
        //SceneManager.LoadScene("CreditsScene");
    }
    public void LoadHowToPlayScene()
    {
        LoadingScene.instance.ChangSceneOnClick(21);
        //SceneManager.LoadScene("HTPScene");
    }
    public void LoadLibraryScene()
    {
        LoadingScene.instance.ChangSceneOnClick(19);
        //SceneManager.LoadScene("LibraryScene");
    }
    public void LoadShopScene()
    {
        LoadingScene.instance.ChangSceneOnClick(20);
        //SceneManager.LoadScene("ShopScene");
    }

    public void LoadLevelScene()
    {
        LoadingScene.instance.ChangSceneOnClick(2);
        //SceneManager.LoadScene("LevelScene");
        Time.timeScale = 1;
    }

    public void LoadLevel1()
    {
        Time.timeScale = 1;
        LoadingScene.instance.ChangSceneOnClick(3);
        //SceneManager.LoadScene("Level1");
    }
    public void LoadLevel2()
    {
        Time.timeScale = 1;
        LoadingScene.instance.ChangSceneOnClick(4);
        //SceneManager.LoadScene("Level2");
    }
    public void LoadLevel3()
    {
        Time.timeScale = 1;
        LoadingScene.instance.ChangSceneOnClick(5);
        //SceneManager.LoadScene("Level3");
    }
    public void LoadLevel4()
    {
        LoadingScene.instance.ChangSceneOnClick(6);
        //SceneManager.LoadScene("Level4");
        Time.timeScale = 1;
    }
    public void LoadLevel5()
    {
        LoadingScene.instance.ChangSceneOnClick(7);
        //SceneManager.LoadScene("Level5");
        Time.timeScale = 1;
    }
    public void LoadLevel6()
    {
        LoadingScene.instance.ChangSceneOnClick(8);
        //SceneManager.LoadScene("Level6");
        Time.timeScale = 1;
    }
    public void LoadLevel7()
    {
        LoadingScene.instance.ChangSceneOnClick(9);
        //SceneManager.LoadScene("Level7");
        Time.timeScale = 1;
    }
    public void LoadLevel8()
    {
        LoadingScene.instance.ChangSceneOnClick(10);
        //SceneManager.LoadScene("Level8");
        Time.timeScale = 1;
    }
    public void LoadLevel9()
    {
        LoadingScene.instance.ChangSceneOnClick(11);
        //SceneManager.LoadScene("Level9");
        Time.timeScale = 1;
    }
    public void LoadLevel10()
    {
        LoadingScene.instance.ChangSceneOnClick(12);
        //SceneManager.LoadScene("Level10");
        Time.timeScale = 1;
    }
    public void LoadLevel11()
    {
        LoadingScene.instance.ChangSceneOnClick(13);
        //SceneManager.LoadScene("Level11");
        Time.timeScale = 1;
    }
    public void LoadLevel12()
    {
        LoadingScene.instance.ChangSceneOnClick(14);
        //SceneManager.LoadScene("Level12");
        Time.timeScale = 1;
    }
    //public void QuitGame()
    //{
    //    UnityEngine.Application.Quit();
    //}
}
