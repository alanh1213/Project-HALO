using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;

public class Jugador_Arma : MonoBehaviour
{
    Animator armaAnimator;
    string estadoActual;
    public string armaEquipada = "AR";

    void Awake()
    {
        armaAnimator = transform.Find("ArmaGFX").GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    
    public void ApuntarAlMouse()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        Quaternion rotacion = Quaternion.Euler(aimDirection);
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        if(angle < 40 && angle > -40)
        {
            transform.eulerAngles = new Vector3 (0, 0, angle);
        }

        if(Input.GetKey(KeyCode.Mouse0))
        {
            CambiarEstadoArma("SHOT");
        }else
        {
            CambiarEstadoArma("IDLE");
        }
    }
    
    

    private void CambiarEstadoArma(string nuevoEstado)
    {
        if(estadoActual == nuevoEstado) return;

        switch(armaEquipada)
        {
            case("AR"):
            armaAnimator.Play("AR_"+ nuevoEstado);
            break;
            case("SMG"):
            armaAnimator.Play("SMG_"+ nuevoEstado);
            break;
            case("SHOTGUN"):
            break;
            case("SPKR"):
            armaAnimator.Play("SPKR_"+ nuevoEstado);
            break;
            case("BR"):
            break;
            case("SNIPER"):
            break;
        }
        
        
        estadoActual = nuevoEstado;
    }

    public void ResetearPosicion()
    {
        transform.eulerAngles = new Vector3(0,0,0);
    }

    enum AR {AR_IDLE, AR_SHOT, AR_AIM, AR_MOVING, AR_AIMTHROW, AR_MOVING_THROW, AR_RELOAD, AR_IDLE_2};
}
