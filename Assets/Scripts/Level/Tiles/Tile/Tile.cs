using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tile : TileAnimator
{    
    public int X;
    public int Y;

    public Tile Left;
    public Tile Right;
    public Tile Up;
    public Tile Down;

    public IAction CurrentAction = null;    
    public TileVisuals visual;

    public int State;
    public int EndState;

    public Color[] colorSchema;

    void Start()
    {        
        visual = gameObject.GetComponentInChildren<TileVisuals>();

        // ShowFront(0.1f);

        AnimationQueue.Enqueue(Animation.Delay(X * 0.1f));        
        AnimationQueue.Enqueue(AnimationWithCallback.Create(
            Animation.Create(UpdateRotation, Easings.Functions.QuadraticEaseInOut, 1.0f, 0, 180.0f),
            null,
            () => {
                visual.backColor = colorSchema[0];
                visual.backIcon = TileIcon.Blank;
            }
        ));
    }

    void Awake(){

    }
    
    void Update()
    {        
        UpdateAnimation();
    }

    void UpdateRotation(float value){        
        gameObject.transform.rotation = Quaternion.Euler(0, value, 0);
    }

    public void InitializeStates(int currentState, int endState){
        State = currentState;
        EndState = endState;
        gameObject.GetComponentInChildren<TileVisuals>().CreateMaterialAndSetColor(colorSchema[currentState], colorSchema[endState]);
    }

    public IEnumerable<Tile> GetSurroundingTiles(){
        var result = new List<Tile>();
        if(Up != null){
            result.Add(Up);
        }
        if(Down != null){
            result.Add(Down);
        }
        if(Left != null){
            result.Add(Left);
        }
        if(Right != null){
            result.Add(Right);
        }
        return result;
    }

    public void InitializeNeighbours(IEnumerable<Tile> tiles, int maxX, int maxY)
    {        
        var lookUp = tiles.ToDictionary(tile  => (tile.X, tile.Y));
        
        if(X > 0){
            Right = lookUp[(X-1, Y)];
        }
        
        if(X < maxX-1){
            Left = lookUp[(X+1, Y)];
        }

        if(Y > 0){
            Up = lookUp[(X, Y-1)];
        }
        
        if(Y < maxY-1){
            Down = lookUp[(X, Y+1)];
        }
        
    }

    public void StartAnimation(IAnimation animation){
        AnimationQueue.Enqueue(animation);
    }

    internal void ShowBack(float duration = 1.0f)
    {                
        AnimationQueue.Enqueue(Animation.Create(UpdateRotation, Easings.Functions.QuadraticEaseInOut, duration, 180.0f, 0.0f));
    }

    internal void ShowFront(float duration = 1.0f)
    {        
        AnimationQueue.Enqueue(Animation.Create(UpdateRotation, Easings.Functions.QuadraticEaseInOut, duration, 0, 180.0f));        
    }

    internal void TurnColor(Color newColor)
    {
        var animation = AnimationWithCallback.Create(
            CurrentAction.CreateFadeOutAnimation(),
            null,
            () => {
                visual.backIcon = TileIcon.Blank;
            }
        );
    }

    internal void ShowColorSideAndHideAction()
    {        
        if(CurrentAction != null){

            var animation = AnimationWithCallback.Create(
                CurrentAction.CreateFadeOutAnimation(),
                null,
                () => {
                    visual.backIcon = TileIcon.Blank;
                    visual.backColor = colorSchema[0];
                }
            );
            
            AnimationQueue.Enqueue(animation);

            CurrentAction = null;
        }        
    }

    internal void SetActionAndShowActionSide(string actionType, int state)
    {               
        var currentAction = ActionFactory.CreateAction(actionType, this, state);
        CurrentAction = currentAction;

        var animation = AnimationWithCallback.Create(
                currentAction.CreateFadeInAnimation(),
                () => {
                    visual.backColor = colorSchema[state];
                    visual.backIcon = currentAction.Icon;
                }
            );

        AnimationQueue.Enqueue(animation);
    }
}
