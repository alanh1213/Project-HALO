using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Layer : MonoBehaviour
{
    private SpriteRenderer sprite_Renderer;
    [SerializeField] private SpriteRenderer parentSpriteRenderer;
    [SerializeField] private bool es_Brazo = false;
    private Transform spriteDetector;

    private void Awake()
    {
        sprite_Renderer = GetComponent<SpriteRenderer>();
        spriteDetector = gameObject.transform.Find("SpriteDetector");
    }
    private void Update()
    {
        if(!es_Brazo)sprite_Renderer.sortingOrder = -(int) spriteDetector.transform.position.y;
        else sprite_Renderer.sortingOrder = parentSpriteRenderer.sortingOrder;
    }
}
