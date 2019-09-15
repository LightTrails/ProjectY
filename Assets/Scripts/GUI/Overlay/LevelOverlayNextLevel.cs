using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverlayNextLevel : MonoBehaviour
{
    public void LoadNextLevel(){
        var levels = Resources.LoadAll<TextAsset>("Levels");
        var levelNames = levels.Select(x=>x.name).ToList();
        
        
        var index = levelNames.IndexOf(Overview.SelectedTextAsset.name);
        var nextLevelName = levelNames[index+1];
        
        Overview.SelectedTextAsset = levels.First(x=>x.name == nextLevelName);

        SceneManager.LoadScene("Level");
    }
}
