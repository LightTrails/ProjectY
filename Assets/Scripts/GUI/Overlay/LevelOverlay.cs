using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelOverlay : AnimatedObject
{
    public LevelOverlayNextLevel nextLevelButton;
    public LevelOverlayRestartLevel restartButton;

    public Color Green = Color.green; 
    public Color Red = Color.red;

    public void UpdatePostion(float position)
    {
        transform.localPosition = new Vector3(0.0f, position, 0.0f);
    }

    public void StartAnimation() {
        UpdatePostion(1000);
        AnimationQueue.Enqueue(Animation.Create(UpdatePostion, Easings.Functions.QuadraticEaseOut, 0.5f, 1000, 0));
    }

    void Update(){        
        UpdateAnimation();
    }

    public void ShowWinnerScene(){
        gameObject.SetActive(true);
        GetComponent<Image>().color = Green;
        FindObjectOfType<CelebrationParticles>().Play();
        GetComponentInChildren<TextMeshProUGUI>().text = "You WON, next challenge please...";
        nextLevelButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        StartAnimation();
    }

    public void ShowLooserScene(){
        
        GetComponent<Image>().color = Red;
        gameObject.SetActive(true);
        GetComponentInChildren<TextMeshProUGUI>().text = "You have no more moves, try again";        
        nextLevelButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        StartAnimation();
    }
}

