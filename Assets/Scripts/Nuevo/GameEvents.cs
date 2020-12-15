using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    private void Awake()
    {
        current = this;
    }

    public event Action enModoCinemaActivado;
    public event Action enModoCinemaDesactivado;

    public void ModoCinemaActivado()
    {
        if(enModoCinemaActivado != null)
        {
            enModoCinemaActivado();
        }
    }

    public void ModoCinemaDesactivado()
    {
        if(enModoCinemaActivado != null)
        {
            enModoCinemaDesactivado();
        }
    }
}
