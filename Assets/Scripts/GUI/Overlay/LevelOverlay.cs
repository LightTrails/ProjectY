using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOverlay : AnimatedObject
{
    public LevelOverlayNextLevel nextLevelButton;
    public LevelOverlayRestartLevel restartButton;

    public void UpdatePostion(float position)
    {
        transform.localPosition = new Vector3(0.0f, position, 0.0f);
    }

    public void StartAnimation() {
        UpdatePostion(1000);
        AnimationQueue.Enqueue(Animation.Create(UpdatePostion, Easings.Functions.QuadraticEaseOut, 1, 1000, 0));
    }

    void Update(){        
        UpdateAnimation();
    }

    public void ShowWinnerScene(){
        gameObject.SetActive(true);
        FindObjectOfType<CelebrationParticles>().Play();
        GetComponentInChildren<Text>().text = "You Won!";
        nextLevelButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        StartAnimation();
    }

    public void ShowLooserScene(){
        gameObject.SetActive(true);
        GetComponentInChildren<Text>().text = "You Lost!";
        nextLevelButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        StartAnimation();
    }
}

