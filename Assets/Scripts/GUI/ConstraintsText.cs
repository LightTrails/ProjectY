using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstraintsText : MonoBehaviour
{
    public void UpdateText(int movesLeft){
        GetComponent<Text>().text = "Moves Left: " + movesLeft;
    } 

    public void ShowWinText(){
        GetComponent<Text>().text = "You are a winner! :D";
    } 

    public void ShowLooseText(){
        GetComponent<Text>().text = "You lost, click reset to try again";
    } 
}
