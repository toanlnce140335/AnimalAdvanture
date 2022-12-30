using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelected : MonoBehaviour
{
    public bool enableSelectCharacter;
    public enum Player { Human, FemaleHuman, Monkey, Rhino, Pangolin};
    public Player playerSelected;

    public Image image;
    public Text CharacterName;

    public Sprite[] playerImage;

    void Start()
    {
        if (!enableSelectCharacter)
        {
            ChangePlayerInMenu();
        }
        else
        {
            switch (playerSelected)
            {
                case Player.Human:
                    CharacterName.text = "Human";
                    image.sprite = playerImage[0];
                    break;
                case Player.FemaleHuman:
                    CharacterName.text = "Female Human";
                    image.sprite = playerImage[1];
                    break;
                case Player.Monkey:
                    CharacterName.text = "Monkey";
                    image.sprite = playerImage[2];
                    break;
                case Player.Rhino:
                    CharacterName.text = "Rhino";
                    image.sprite = playerImage[3];
                    break;
                case Player.Pangolin:
                    CharacterName.text = "Pangolin";
                    image.sprite = playerImage[4];
                    break;
                default:
                    break;
            }
        }
    }
    public void ChangePlayerInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "Human":
                CharacterName.text = "Human";
                image.sprite = playerImage[0];
                break;
            case "FemaleHuman":
                CharacterName.text = "Female Human";
                image.sprite = playerImage[1];
                break;
            case "Monkey":
                CharacterName.text = "Monkey";
                image.sprite = playerImage[2];
                break;
            case "Rhino":
                CharacterName.text = "Rhino";
                image.sprite = playerImage[3];
                break;
            case "Pangolin":
                CharacterName.text = "Pangolin";
                image.sprite = playerImage[4];
                break;
            default:
                break;
        }
    }
}
