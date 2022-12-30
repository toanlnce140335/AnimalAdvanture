using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    private Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;
    private bool isOn = true;
    public AudioSource audioSource;

    void Start()
    {        
        ChangeIcon();
        Load();
    }

    public void ChangeIcon()
    {
        if (isOn)
        {
            soundOnImage = button.image.sprite;
        }
        else
        {
            soundOffImage = button.image.sprite;
        }
    }

    public void onClicked()
    {
        if (isOn)
        {
            button.image.sprite = soundOffImage;
            isOn = false;
            audioSource.mute = true;
            AudioListener.volume = 0;
        }
        else
        {
            button.image.sprite = soundOnImage;
            isOn = true;
            audioSource.mute = false;
            AudioListener.volume = 1;
        }
        Save();
    }

    private void Load()
    {
        isOn = PlayerPrefs.GetInt("Muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Muted", isOn ? 1 : 0);
    }
}
