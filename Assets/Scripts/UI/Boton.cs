using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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

    public void IniciarPartida()
    {
        SceneManager.LoadSceneAsync("mision1_2");
    }

    public void Pausa()
    {
        GameEvents.current.ModoPausa();
    }

    public void VolverAlMenuPrincipal()
    {
        SceneManager.LoadSceneAsync(0);
    }
    
}
