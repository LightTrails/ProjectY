using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugEditor : MonoBehaviour
{
    public bool EditMode = false;

    public Color Color => GetComponentInChildren<Panel>().color;
    public int State => GetComponentInChildren<Panel>().state;

    // Start is called before the first frame update
    void Start()
    {
        transform.Find("Panel").gameObject.SetActive(EditMode);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)){
            EditMode = !EditMode;
            transform.Find("Panel").gameObject.SetActive(EditMode);
            if(EditMode){

                var levelSelctors = FindObjectOfType(typeof(LevelSelector)) as LevelSelector;
                levelSelctors.UnselectAll();
            }                        
        }
    }
}
