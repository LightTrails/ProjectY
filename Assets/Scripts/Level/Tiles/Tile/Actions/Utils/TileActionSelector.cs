using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileActionSelector : MonoBehaviour
{
    void Update()
    {
        if ( Input.GetMouseButtonDown (0)){ 
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if ( Physics.Raycast (ray, out hit, 200.0f)) {
                if (hit.collider.gameObject == gameObject){
                    var levelSelector = GetComponentInParent<LevelSelector>();
                    var tile = GetComponentInParent<Tile>();

                    if(tile.CurrentAction != null){
                        tile.CurrentAction.Activate();

                        levelSelector.UnselectAll();
                    }
                }
            }
        }
    }
}
