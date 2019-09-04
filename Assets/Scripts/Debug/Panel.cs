using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public Color color;
    public int state;

    public Level level;

    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        this.material = GetComponentInChildren<MeshRenderer>().material;
        level = FindObjectOfType<Level>() as Level;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {            
            state = 0;
            color = level.Schema[0];
            UpdateColor();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)){
            state = 1;
            color = level.Schema[1];
            UpdateColor();
        }

        if(Input.GetKeyDown(KeyCode.Alpha3)){
            state = 2;
            color = level.Schema[2];
            UpdateColor();
        }

        if(Input.GetKeyDown(KeyCode.Alpha4)){
            state = 3;
            color = level.Schema[3];
            UpdateColor();
        }

        if(Input.GetKeyDown(KeyCode.Alpha5)){
            state = 4;
            color = level.Schema[4];
            UpdateColor();
        }

        if(Input.GetKeyDown(KeyCode.Alpha6)){
            state = 5;
            color = level.Schema[5];
            UpdateColor();
        }

        if(Input.GetKeyDown(KeyCode.Alpha7)){
            state = 6;
            color = level.Schema[6];
            UpdateColor();
        }

        if(Input.GetKeyDown(KeyCode.Alpha8)){
            state = 7;
            color = level.Schema[7];
            UpdateColor();
        }
    }

    private void UpdateColor()
    {
        this.material.SetColor("_Color", color);
    }
}
