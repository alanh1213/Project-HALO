using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_Visor : MonoBehaviour
{
    private Animator animator;
    [HideInInspector]
    public string estadoActual;
    void Awake()
    {
      animator = GetComponent<Animator>();  
    }

    void Start()
    {
        estadoActual = "OFF";
    }

    public void ActivarDesactivarVisor(string nuevoEstado)
    {
        if(nuevoEstado == estadoActual) return;

        animator.Play(nuevoEstado);

        estadoActual = nuevoEstado;
    }
}
