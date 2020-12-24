using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Texto : MonoBehaviour
{
    TextMeshProUGUI texto_Cinema;

    private void Awake()
    {
        texto_Cinema = GetComponent<TextMeshProUGUI>();
    }

    static void EscribirTexto(string texto)
    {
        
    }
}
