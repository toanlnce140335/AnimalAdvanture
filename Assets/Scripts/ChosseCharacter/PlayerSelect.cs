using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectCharacter;

    public enum Player { Human, FemaleHuman, Monkey, Rhino, Pangolin};
    public Player playerSelected;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playersController;
    public Sprite[] playersRenderer;

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
                    spriteRenderer.sprite = playersRenderer[0];
                    animator.runtimeAnimatorController = playersController[0];
                    break;
                case Player.FemaleHuman:
                    spriteRenderer.sprite = playersRenderer[1];
                    animator.runtimeAnimatorController = playersController[1];
                    break;
                case Player.Monkey:
                    spriteRenderer.sprite = playersRenderer[2];
                    animator.runtimeAnimatorController = playersController[2];
                    break;
                case Player.Rhino:
                    spriteRenderer.sprite = playersRenderer[3];
                    animator.runtimeAnimatorController = playersController[3];
                    break;
                case Player.Pangolin:
                    spriteRenderer.sprite = playersRenderer[4];
                    animator.runtimeAnimatorController = playersController[4];
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
                spriteRenderer.sprite = playersRenderer[0];
                animator.runtimeAnimatorController = playersController[0];
                break;
            case "FemaleHuman":
                spriteRenderer.sprite = playersRenderer[1];
                animator.runtimeAnimatorController = playersController[1];
                break;
            case "Monkey":
                spriteRenderer.sprite = playersRenderer[2];
                animator.runtimeAnimatorController = playersController[2];
                break;
            case "Rhino":
                spriteRenderer.sprite = playersRenderer[3];
                animator.runtimeAnimatorController = playersController[3];
                break;
            case "Pangolin":
                spriteRenderer.sprite = playersRenderer[4];
                animator.runtimeAnimatorController = playersController[4];
                break;
            default:
                break;
        }
    }
}
