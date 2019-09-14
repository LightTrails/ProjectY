using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverviewButton : MonoBehaviour
{
    public TextAsset TextAsset;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTextAsset(TextAsset textAsset)
    {
        TextAsset = textAsset;
        GetComponentInChildren<Text>().text = textAsset.name;
    }

    public void LoadLevel()
    {        
        Overview.SelectedTextAsset = TextAsset;
        SceneManager.LoadScene("Level");
    }
}
