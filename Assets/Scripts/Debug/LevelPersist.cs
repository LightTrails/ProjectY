using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelPersist : MonoBehaviour
{
    public Level level;

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType(typeof(Level)) as Level;        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.L)){
            Load();
        }
    }

    private void Load(){
        var loadedContent = File.ReadAllText(@"C:\Debug\Level1.json");
        var loadedJson = JsonUtility.FromJson<SLevel>(loadedContent);
        
        level.CreateLevel(loadedJson);
    }

    private void Save()
    {
        /*var tiles = level.GetComponentsInChildren<Tile>();

        var slevel = new SLevel(){
            Dimensions = level.Dimensions
        };

        foreach (var tile in tiles)
        {
            slevel.Tiles.Add(new STile()
            {
                Coordinate = new Vector2(tile.X, tile.Y),
                State = tile.State
            });
        }

        var json = JsonUtility.ToJson(slevel);
        File.WriteAllText(@"C:\Debug\Level1.json", json);

        Debug.Log("Saved");*/
    }
}
