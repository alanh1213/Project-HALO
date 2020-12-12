using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Civil : MonoBehaviour, IDamagable
{
    [SerializeField] private int vida = 1500;
    [SerializeField] private GameObject fuegoPrefab;
    [SerializeField] private GameObject explosionPrefab;
    private string estadoActual;
    private Animator animator;
    private bool exploto = false;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start() 
    {
        estadoActual = SIN_DAÑO;
        explosionPrefab.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        fuegoPrefab.transform.localScale = new Vector3(1.5f, 1.2f, 0.8f);
    }

    private void Update() 
    {
        if(vida >= 1500)
        {
            CambiarEstadoAnimacion(SIN_DAÑO);
        }
        else if(vida < 1500 && vida > 1000)
        {
            CambiarEstadoAnimacion(AUTO_DAÑO_MINIMO);
        }
        else if(vida < 1000 && vida > 0)
        {
            CambiarEstadoAnimacion(AUTO_DAÑO_MODERADO);
        }
        else if(vida <= 0 && !exploto)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Instantiate(fuegoPrefab, transform.position, Quaternion.identity);
            CambiarEstadoAnimacion(AUTO_DAÑO_DESTRUIDO);
            exploto = true;
        }
    }
    public void TakeDamage(int daño)
    {
        vida -= daño;
    }

    void CambiarEstadoAnimacion(string nuevoEstado)
    {
        if(estadoActual == nuevoEstado) return;

        animator.Play(nuevoEstado);

        estadoActual = nuevoEstado;

    }

    private const string SIN_DAÑO = "Sin_Daño";
    private const string AUTO_DAÑO_MINIMO = "Auto_Daño_Minimo";
    private const string AUTO_DAÑO_MODERADO = "Auto_Daño_Moderado";
    private const string AUTO_DAÑO_DESTRUIDO = "Auto_Daño_Destruido";


}
