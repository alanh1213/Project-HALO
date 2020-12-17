using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Jugador : MonoBehaviour
{
    private GameObject pausaGO;
    void Start()
    {
        pausaGO = transform.Find("Menu_Pausa").gameObject;
        GameEvents.current.enModoPausa += Pausa;
    }

    void Pausa()
    {
        if(Time.timeScale == 1 && !pausaGO.activeSelf)
        {
            Time.timeScale = 0;
            pausaGO.SetActive(true);
        }else if(Time.timeScale == 0 && pausaGO.activeSelf)
        {
            Time.timeScale = 1;
            pausaGO.SetActive(false);
        }
    }
}
