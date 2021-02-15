using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour, IDamagable
{
    [SerializeField] private float vidaJugador = 100f;
    public void TakeDamage(int daño)
    {
        vidaJugador -= daño;
    }
}
