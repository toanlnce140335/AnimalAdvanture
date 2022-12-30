using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDoorSkins : MonoBehaviour
{
    public GameObject skinsPanel;

    public GameObject CharacterSelected;

    [SerializeField] public AudioSource cannotchoose;
    [SerializeField] public GameObject requestBuyCoin;

    public GameObject player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            skinsPanel.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        skinsPanel.gameObject.SetActive(false);
    }

    public void SetPlayerFemaleHuman()
    {
        int price = 10;
        if (PlayerPrefs.GetInt("FemaleHumanBought") == 1)
        {
            price = 0;
        }

        if (ScoreHandler.instance.Coins >= price)
        {
            ScoreHandler.instance.removeCoins(price);
            PlayerPrefs.SetInt("FemaleHumanBought", 1);
            PlayerPrefs.SetString("PlayerSelected", "FemaleHuman");
            ResetPlayerSkin();
        }
        else
        {
            cannotchoose.PlayOneShot(cannotchoose.clip);
        }
    }

    public void SetPlayerHuman()
    {
        int price = 10;
        if (PlayerPrefs.GetInt("HumanBought") == 1)
        {
            price = 0;
        }

        if (ScoreHandler.instance.Coins >= price)
        {
            ScoreHandler.instance.removeCoins(price);
            PlayerPrefs.SetInt("HumanBought", 1);
            PlayerPrefs.SetString("PlayerSelected", "Human");
            ResetPlayerSkin();
        }
        else
        {
            cannotchoose.PlayOneShot(cannotchoose.clip);
        }
    }

    public void SetPlayerMonkey()
    {
        int price = 50;
        if (PlayerPrefs.GetInt("MonkeyBought") == 1)
        {
            price = 0;
        }

        if (ScoreHandler.instance.Coins >= price)
        {
            ScoreHandler.instance.removeCoins(price);
            PlayerPrefs.SetInt("MonkeyBought", 1);
            PlayerPrefs.SetString("PlayerSelected", "Monkey");
            ResetPlayerSkin();
        }
        else
        {
            requestBuyCoin.SetActive(true);
            cannotchoose.PlayOneShot(cannotchoose.clip);
        }
    }

    public void SetPlayerRhino()
    {
        int price = 100;
        if (PlayerPrefs.GetInt("RhinoBought") == 1)
        {
            price = 0;
        }

        if (ScoreHandler.instance.Coins >= price)
        {
            ScoreHandler.instance.removeCoins(price);
            PlayerPrefs.SetInt("RhinoBought", 1);
            PlayerPrefs.SetString("PlayerSelected", "Rhino");
            ResetPlayerSkin();
        }
        else
        {
            requestBuyCoin.SetActive(true);
            cannotchoose.PlayOneShot(cannotchoose.clip);
        }
    }

    public void SetPlayerTete()
    {
        int price = 150;
        if (PlayerPrefs.GetInt("PangolinBought") == 1)
        {
            price = 0;
        }

        if (ScoreHandler.instance.Coins >= price)
        {
            ScoreHandler.instance.removeCoins(price);
            PlayerPrefs.SetInt("PangolinBought", 1);
            PlayerPrefs.SetString("PlayerSelected", "Pangolin");
            ResetPlayerSkin();
        }
        else
        {
            requestBuyCoin.SetActive(true);
            cannotchoose.PlayOneShot(cannotchoose.clip);
        }
    }

    void ResetPlayerSkin()
    {
        skinsPanel.gameObject.SetActive(false);
        CharacterSelected.gameObject.SetActive(true);
    }
}
