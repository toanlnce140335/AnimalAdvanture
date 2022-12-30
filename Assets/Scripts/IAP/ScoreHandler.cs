using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public int Coins;

    string CoinsOfGamePlayerPrefsName = "Coins";

    public static ScoreHandler instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        loadCoinsFromPlayerPrefs();
    }

    public void increaseCoins(int valueToAdd)
    {
        Coins += valueToAdd;
        saveCoinsToPlayerPrefs();
    }
    //exit

    public void removeCoins(int CoinsToRemove) 
    {
        Coins -= CoinsToRemove;
    }
    //exit

    void saveCoinsToPlayerPrefs()
    {
        PlayerPrefs.SetInt(CoinsOfGamePlayerPrefsName, Coins);
    }
    //exit

    void loadCoinsFromPlayerPrefs()
    {
        Coins = PlayerPrefs.GetInt(CoinsOfGamePlayerPrefsName, 0);
    }
    //exit
}
