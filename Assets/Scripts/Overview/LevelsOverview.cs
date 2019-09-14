using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsOverview : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var levels = Resources.LoadAll<TextAsset>("Levels");
        RemoveChildrensUnderGameObject(gameObject);

        var levelPrefab = Resources.Load("Overview/Level") as GameObject;

        foreach (var level in levels)
        {
            var levelInstance = GameObject.Instantiate(levelPrefab);
            levelInstance.name = level.name;
            levelInstance.transform.SetParent(gameObject.transform);
            levelInstance.GetComponent<LevelOverviewButton>().SetTextAsset(level);
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
