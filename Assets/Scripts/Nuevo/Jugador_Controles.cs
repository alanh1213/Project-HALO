using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_Controles : MonoBehaviour
{
    Move_RB2D move_RB2D;
    Jugador_Arma jugador_Arma;
    Jugador_Cabeza jugador_Cabeza;
    private void Awake()
    {
        move_RB2D = GetComponent<Move_RB2D>();
        jugador_Arma = gameObject.transform.Find("Arma").GetComponent<Jugador_Arma>();
        jugador_Cabeza = gameObject.transform.Find("Cabeza").GetComponent<Jugador_Cabeza>();
    }
    private void Update()
    {

        Vector3 vectorDeMovimiento = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);
        move_RB2D.SetVelocity(vectorDeMovimiento);

        //-------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------
        
        if(Input.GetKey(KeyCode.Mouse1))
        {
            jugador_Arma.ApuntarAlMouse();
            jugador_Cabeza.ApuntarAlMouse();
        }else
        {
            //jugador_Arma.Invoke("ResetearPosicion", 1.5f);
            //jugador_Cabeza.Invoke("ResetearPosicion", 1.5f);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameEvents.current.ModoPausa();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            jugador_Arma.CambiarEstadoArma("RELOAD");
        }
    }
    private const string CONTROLES_HALOCE = "Controles Halo CE";
}