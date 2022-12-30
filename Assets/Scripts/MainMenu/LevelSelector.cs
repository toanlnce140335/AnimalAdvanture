﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }
}
