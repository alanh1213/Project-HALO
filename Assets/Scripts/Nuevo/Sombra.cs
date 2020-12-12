using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sombra : MonoBehaviour
{
    private GameObject sombraGO;
    private SpriteRenderer sombraSpriteRenderer, thisSpriteRenderer;
    [SerializeField] private float offSetSombra = 3;
    [SerializeField] private float horaDeSol = -0.4f;



    void Start()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        CrearSombra();
    }

    void Update()
    {
        sombraGO.transform.position = new Vector3(transform.position.x ,transform.position.y - offSetSombra, transform.position.z);
        sombraSpriteRenderer.sprite = thisSpriteRenderer.sprite;
    }

    void CrearSombra()
    {
        sombraGO = new GameObject("Sombra");
        sombraGO.transform.parent = this.gameObject.transform;
        sombraGO.transform.localScale = new Vector3(1, horaDeSol, sombraGO.transform.localScale.z);
        sombraGO.transform.position = new Vector3(transform.position.x ,transform.position.y - offSetSombra, transform.position.z);
        sombraGO.AddComponent<SpriteRenderer>();
        sombraSpriteRenderer = sombraGO.GetComponent<SpriteRenderer>();
        sombraSpriteRenderer.sprite = thisSpriteRenderer.sprite;
        sombraSpriteRenderer.color = new Color(0,0,0, 0.45f);
        sombraSpriteRenderer.sortingLayerName = thisSpriteRenderer.sortingLayerName;
        sombraSpriteRenderer.sortingOrder = thisSpriteRenderer.sortingOrder + 1;
    }
}
