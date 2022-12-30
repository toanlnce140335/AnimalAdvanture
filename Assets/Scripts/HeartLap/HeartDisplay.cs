using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    public PlayerHealth playerHealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = playerHealth.health;
        maxHealth = playerHealth.maxHealth;

       for(int i =0; i < hearts.Length; i++)
        {
            if (i == health)
            {
                hearts[health].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        } 
    }
}
