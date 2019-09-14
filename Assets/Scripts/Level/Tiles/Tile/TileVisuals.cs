using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileVisuals : MonoBehaviour
{    
    public TileIcon frontIcon = TileIcon.Blank;
    public Color frontColor = new Color(1,1,1,1);

    public TileIcon backIcon = TileIcon.Blank;
    public Color backColor = new Color(1,1,1,1);

    private GameObject Front => transform.Find("Front").gameObject;
    private GameObject Back => transform.Find("Back").gameObject;

    void Start()
    {        
        UpdateVisuals();
    }
    
    void Update()
    {          
        UpdateVisuals();
    }

    public void UpdateVisuals(){
        SetIconAndColor(Front, frontIcon, frontColor);
        SetIconAndColor(Back, backIcon, backColor);
    }

    public void CreateMaterialAndSetColor(Color frontColor, Color backColor)
    {
        this.frontColor = frontColor;
        this.backColor = backColor;
        
        CreateMaterial(Front, frontColor);
        CreateMaterial(Back, backColor);
    }

    private void CreateMaterial(GameObject gameObject, Color color)
    {
        var newMaterial = new Material(Shader.Find("Unlit/TileShader"));
        newMaterial.SetColor("_Color", color);
        gameObject.GetComponentInChildren<Icon>().GetComponent<MeshRenderer>().material = newMaterial;
    }

    private void SetIconAndColor(GameObject gameObject, TileIcon tileIcon, Color color){
        SetIcon(gameObject, tileIcon);
        SetColor(gameObject, color);
    }

    private void SetColor(GameObject gameObject, Color color)
    {                
        gameObject.GetComponentInChildren<Icon>().GetComponent<MeshRenderer>().material.SetColor("_Color", color);
    }

    private void SetIcon(GameObject gameObject,TileIcon tileIcon)
    {
        var iconInfo = TileIconsRepository.TileIconRendererDictionary[tileIcon];
        var texture = Resources.Load("Tile/Icons/"+iconInfo.ResourceName);
        transform.localRotation = Quaternion.Euler(0, 0, iconInfo.Rotation);
        gameObject.GetComponentInChildren<Icon>().GetComponent<MeshRenderer>().material.SetTexture("_MainTex", texture as Texture2D);
    }
}
