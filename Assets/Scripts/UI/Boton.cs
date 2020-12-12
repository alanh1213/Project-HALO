using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Boton : MonoBehaviour
{   
    public bool botonJugar = false;
    void OnEnable()
    {
        if(botonJugar)EventSystem.current.SetSelectedGameObject(gameObject);
    }


    void OnPointerStay(PointerEventData eventData)
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
        
    }

    public void CerrarAplicacion()
    {
        Application.Quit();
    }
    
}
