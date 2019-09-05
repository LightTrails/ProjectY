using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelActions : MonoBehaviour
{    
    public void ResetLevel(){
        GetComponent<LevelSelector>().UnselectAll();

        foreach (var tile in GetComponentsInChildren<Tile>())
        {
            tile.TurnToOriginalColor();
        }

        GetComponent<LevelConstraints>().Reset();
    }


    public void ShowEndState(){
        GetComponent<LevelSelector>().UnselectAll();

        foreach (var tile in GetComponentsInChildren<Tile>())
        {
            tile.ShowGoalState();
        }
    }
}
