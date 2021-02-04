using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Layer : MonoBehaviour
{
    private SpriteRenderer sprite_Renderer, parent_Sprite_Renderer;
    [SerializeField] private GameObject parentSpriteRendererGO;
    [SerializeField] private bool es_Brazo = false;
    private Transform spriteDetector;

    private void Awake()
    {
        sprite_Renderer = GetComponent<SpriteRenderer>();
        spriteDetector = gameObject.transform.Find("SpriteDetector");
    }

    private void Start()
    {
        parent_Sprite_Renderer = parentSpriteRendererGO.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(!es_Brazo)sprite_Renderer.sortingOrder = -(int) spriteDetector.transform.position.y;
        else sprite_Renderer.sortingOrder = parent_Sprite_Renderer.sortingOrder;
    }
}
