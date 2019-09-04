using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour
{           
    public bool DarkenColor;
    public float DarkenLevel = 0.1f;

    void Update()
    {
        var component = gameObject.GetComponent<MeshRenderer>();
        component.material.SetFloat("_Transparency", DarkenColor ? DarkenLevel : 0.0f);
    }
}
