using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Vector2 Dimensions;
    public Color[] Schema;

    public void CreateLevel(SLevel sLevel)
    {
        Dimensions = sLevel.Dimensions;

        RemoveChildrens();
        var tiles = new List<Tile>();

        var tileByCoordinates = sLevel.Tiles.ToDictionary(x=>x.Coordinate);

        var maxX = (int)sLevel.Dimensions.x;
        var maxY = (int)sLevel.Dimensions.y;

        for (int i = 0; i < maxX; i++)
        {
            for (int j = 0; j < maxY; j++)
            {
                var prefab = Resources.Load("Levels/Tile/Tile") as GameObject;
                var distance = 1.15f;

                var tempobj = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.Euler(0,0,0));
                var tile = tempobj.GetComponent<Tile>();
                tile.X = i;
                tile.Y = j;

                tile.colorSchema = Schema;

                var coordinate = new Vector2(i,j);
                if(tileByCoordinates.ContainsKey(coordinate)){
                    tile.InitializeStates(tileByCoordinates[coordinate].State, tileByCoordinates[coordinate].EndState);
                } else {
                    tile.InitializeStates(0, 0);
                }

                tiles.Add(tile);

                tempobj.name = (i + 1) + "-" + (j + 1);
                tempobj.transform.parent = gameObject.transform;
                tempobj.transform.localPosition =  (sLevel.Dimensions / 2 - new Vector2(i,j)) * distance;
            }
        }

        var constraints = GetComponent<LevelConstraints>();
        constraints.Constraints = sLevel.Constraints;        
            
        foreach (var tile in tiles)
        {
            tile.InitializeNeighbours(tiles, maxX, maxY);
        }
    }

    void RemoveChildrens(){
         var objectsToRemove = new List<GameObject>();
         foreach (Transform item in transform)
         {             
             objectsToRemove.Add(item.gameObject);
         }

         foreach (GameObject child in objectsToRemove){
            GameObject.DestroyImmediate(child);
         }
     }
}
