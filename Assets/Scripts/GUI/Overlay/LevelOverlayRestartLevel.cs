﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverlayRestartLevel : MonoBehaviour
{
    public void RestartLevel(){
        SceneManager.LoadScene("Level");
    }
}
