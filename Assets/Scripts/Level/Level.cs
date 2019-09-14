using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Vector2 Dimensions;
    public Color[] Schema;

    public void Awake(){
        if(Overview.SelectedTextAsset != null){
            var loadedJson = JsonUtility.FromJson<SLevel>(Overview.SelectedTextAsset.text);
            CreateLevel(loadedJson);
        }
    }

    public void CreateLevel(SLevel sLevel)
    {
        Dimensions = sLevel.Dimensions;

        var distance = 1.15f;

        var resultImage = FindObjectOfType<ResultImage>();

        RemoveChildrensUnderGameObject(this.gameObject);
        RemoveChildrensUnderGameObject(resultImage.gameObject);

        var tiles = new List<Tile>();

        var tileByCoordinates = sLevel.Tiles.ToDictionary(x=>x.Coordinate);

        var maxX = (int)sLevel.Dimensions.x;
        var maxY = (int)sLevel.Dimensions.y;

        ((RectTransform)resultImage.transform).sizeDelta = Dimensions * (10*distance) + new Vector2(10, 10);

        for (int i = 0; i < maxX; i++)
        {
            for (int j = 0; j < maxY; j++)
            {            
                var prefab = Resources.Load("Tile/Tile") as GameObject;

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
                tempobj.transform.SetParent(gameObject.transform);
                tempobj.transform.localPosition =  ((sLevel.Dimensions - new Vector2(1,1)) / 2 - new Vector2(i,j)) * distance;

                var previewTilePrefab = Resources.Load("GUI/PreviewTile") as GameObject;
                var previewTile = (GameObject)Instantiate(previewTilePrefab, Vector3.zero, Quaternion.Euler(0,0,0));
                previewTile.transform.SetParent(resultImage.transform);

                var rtf = (RectTransform)previewTile.transform;
                rtf.localScale = new Vector3(1,1,1);
                rtf.anchoredPosition3D = ((sLevel.Dimensions - new Vector2(1,1)) / 2 - new Vector2(i,j)) * (10 * distance);
                previewTile.GetComponent<RawImage>().color = Schema[tileByCoordinates[coordinate].EndState];
                previewTile.name = (i + 1) + "-" + (j + 1);
            }
        }

        var constraints = GetComponent<LevelConstraints>();
        constraints.Constraints = sLevel.Constraints;        
            
        foreach (var tile in tiles)
        {
            tile.InitializeNeighbours(tiles, maxX, maxY);
        }
    }

    void RemoveChildrensUnderGameObject(GameObject gameObject){
         var objectsToRemove = new List<GameObject>();
         foreach (Transform item in gameObject.transform)
         {             
             objectsToRemove.Add(item.gameObject);
         }

         foreach (GameObject child in objectsToRemove){
            GameObject.DestroyImmediate(child);
         }
     }
}
