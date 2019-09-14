using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelConstraints : MonoBehaviour
{
    public SConstraints Constraints;
    public int MovesLeft;

    public bool GameHasEnded = false;
    private ConstraintsText constraintsText;

    void Start(){
        constraintsText = FindObjectOfType(typeof(ConstraintsText)) as ConstraintsText; 
        Reset();
    }

    public void UpdateText(){
        constraintsText.UpdateText(MovesLeft);
    }

    public void Reset(){
        GameHasEnded = false;
        MovesLeft = Constraints.MaxMoves;
        UpdateText();
    }

    public void MoveTaken(){
        MovesLeft--;

        if(GetComponentsInChildren<Tile>().All(x => x.State == x.EndState)){
            constraintsText.ShowWinText();
            FindObjectOfType<CelebrationParticles>().Play();           
            GameHasEnded = true;            
        }
        else if(MovesLeft == 0){
            constraintsText.ShowLooseText();
            GameHasEnded = true;            
        } else {
            UpdateText();        
        }
    }

    public bool CanTakeMoreMoves(){
        return !GameHasEnded;
    }
}
