﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void onStartClick (int level)
    {
        SceneManager.LoadScene(level);
    }
}
