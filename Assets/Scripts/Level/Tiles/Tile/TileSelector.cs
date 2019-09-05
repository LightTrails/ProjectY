using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    public bool Selected;
    public bool IsAction;
    Tile tile;
    
    void Start(){
        tile = GetComponentInParent<Tile>();
    }

    void Update(){
        if ( Input.GetMouseButtonDown (0)){ 
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if ( Physics.Raycast (ray, out hit, 200.0f)) {
                if (hit.collider.gameObject == gameObject && tile.levelConstraints.CanTakeMoreMoves()){
                    var debug = FindObjectOfType(typeof(DebugEditor)) as DebugEditor;
                    if(debug.EditMode){
                        tile.State = debug.State;
                        tile.visual.frontColor = debug.Color;
                        return;
                    }

                    var levelSelector = GetComponentInParent<LevelSelector>();
                    if(Selected){
                        levelSelector.UnselectAll();
                    } else {
                        levelSelector.SelectTile(GetComponentInParent<TileSelector>());
                    }
                }
            }
        }
    }

    internal void UnSelect()
    {
        Selected = false;
        // GetComponentInChildren<Overlay>().DarkenColor = true;

        foreach (var item in tile.GetSurroundingTiles())
        {
            tile.ShowColorSideAndHideAction();
        }
    }

    internal void Select()
    {
        Selected = true;
        // GetComponentInChildren<Overlay>().DarkenColor = false;        
        var state = GetComponentInParent<Tile>().State;

        if(tile.Up != null)
        {
            ShowActionWithIconAndColor(tile.Up, nameof(UpAction), state);
        }

        if (tile.Down != null){
            ShowActionWithIconAndColor(tile.Down, nameof(DownAction), state);
        }

        if(tile.Left != null){
            ShowActionWithIconAndColor(tile.Left, nameof(LeftAction), state);
        }

        if(tile.Right != null){
            ShowActionWithIconAndColor(tile.Right, nameof(RightAction), state);
        }
    }

    private void ShowActionWithIconAndColor(Tile tile, string action, int state)
    {        
        tile.SetActionAndShowActionSide(action, state);
    }
} 
