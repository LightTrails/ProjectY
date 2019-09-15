using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverlayOverview : MonoBehaviour
{
    public void LoadOverview(){
        SceneManager.LoadScene("Overview");
    }
}
