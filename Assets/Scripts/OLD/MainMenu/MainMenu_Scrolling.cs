using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Scrolling : MonoBehaviour
{
    
    Material backgroundMaterial;
    Vector2 offset, end;
    public float xOffset, yOffset;
    
    void Awake()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
    }
    void Start()
    {
        end = new Vector2(1, 0);
        offset = new Vector2(xOffset, yOffset);
    }

    // Update is called once per frame
    void Update()
    {
        backgroundMaterial.mainTextureOffset += offset * Time.deltaTime;
        if(backgroundMaterial.mainTextureOffset.x > end.x)
        {
            backgroundMaterial.mainTextureOffset = new Vector2(0, 0);
        }
    }
}
