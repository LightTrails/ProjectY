using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstraintsText : MonoBehaviour
{
    public void UpdateText(int movesLeft){
        GetComponent<Text>().text = "Moves Left: " + movesLeft;
    } 
}
