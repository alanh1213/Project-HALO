using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Cinema : MonoBehaviour
{
    public GameObject modo_cinema_ui;
    public Animator modo_cinema_anim;
    private string estadoActual;
    void Awake()
    {
        var transform_ui = gameObject.transform.Find("Canvas").transform.Find("CinemaMode");
        modo_cinema_ui = transform_ui.gameObject;
        modo_cinema_anim = modo_cinema_ui.GetComponent<Animator>();
    }

    void Start()
    {
        GameEvents.current.enModoCinemaActivado += ActivarModoCinema;
        GameEvents.current.enModoCinemaDesactivado += DesactivarModoCinema;
    }

    void ActivarModoCinema()
    {
        ReproducirAnimacion(CINEMAMODE_OPEN);
    }

    void DesactivarModoCinema()
    {
        ReproducirAnimacion(CINEMAMODE_EXIT);
    }

    private void ReproducirAnimacion(string nuevoEstado)
    {
        if(estadoActual == nuevoEstado) return;

        modo_cinema_anim.Play(nuevoEstado);

        estadoActual = nuevoEstado;
    }



    private string CINEMAMODE_OPEN = "OPEN";
    private string CINEMAMODE_EXIT = "EXIT";
}
