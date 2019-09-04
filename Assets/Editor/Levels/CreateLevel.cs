using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.IO;

public class CustomWindow  : EditorWindow 
{
     Vector2 levelDimensions = new Vector2(5,5);

    int Selected;

    private string LevelPath = @"C:\Debug\";

    [MenuItem("Tools/CreateLevel")]
    static void Create()
    {
        EditorWindow.GetWindow(typeof(CustomWindow));        
    }

     void OnInspectorUpdate () {
         Repaint ();
     }

     void OnGUI()
     {         
         var level = FindObjectOfType<Level>() as Level;
         
         levelDimensions = EditorGUILayout.Vector2Field("Size:", levelDimensions);         

        var files = Directory.GetFiles(LevelPath);

        string[] options = files.Select(x=> Path.GetFileName(x) ).ToArray();

        Selected = EditorGUILayout.Popup("Input", Selected, options);

        if (GUILayout.Button("Create new level"))
        {
            level.CreateLevel(new SLevel(){
                Dimensions = levelDimensions
            });
        }

        if (GUILayout.Button("Load Level"))
        {
            var loadedContent = File.ReadAllText( Path.Combine(LevelPath, files[Selected]));
            var loadedJson = JsonUtility.FromJson<SLevel>(loadedContent);

            level.CreateLevel(loadedJson);
        }
    }
}
