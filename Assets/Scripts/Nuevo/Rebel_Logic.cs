using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebel_Logic : MonoBehaviour, IDamagable
{
    private Animator rebelAnim, weaponAnim;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private float vida = 150f;
    [SerializeField] private float rangoDeteccion = 25f;
    private float rangoDisparo = 20f;
    private bool enemigoDetectado, unidadMuerta;
    private Transform puntoDisparo, posicionEnemigo, armaTransform;
    private PlayerMovementRB2D playerMovementRB2D;
    private string estadoActual = "IDLE";
    void Awake()
    {
        playerMovementRB2D = GetComponent<PlayerMovementRB2D>();
        rebelAnim = GetComponent<Animator>();
        weaponAnim = gameObject.transform.Find("Weapon").transform.Find("Weapon_Sprite").GetComponent<Animator>();
        puntoDisparo = gameObject.transform.Find("Origen_Disparo").transform;
        posicionEnemigo = transform;
    }

    // Update is called once per frame
    void Update()
    {
        BuscarEnemigo();

        if(vida > 0)
        {
            if(enemigoDetectado)
            {
                
            }else
            {

            }
        }else
        {
            Muerte();
        }
    }

    void BuscarEnemigo()
    {
        Collider2D enemigo = Physics2D.OverlapCircle(transform.position, rangoDeteccion, whatIsEnemy);
        if(enemigo != null)
        {
            enemigoDetectado = true;
            posicionEnemigo = enemigo.transform;
            MoverseHacia(posicionEnemigo.position);
            return;
        }else
        {
            enemigoDetectado = false;
            posicionEnemigo = transform;
            return;
        }
    }

    void MoverseHacia(Vector3 posicion)
    {
        Vector3 vectorNormalizado = (posicion - transform.position).normalized;

        if(Vector2.Distance(transform.position, posicion) > rangoDisparo)
        {
            playerMovementRB2D.SetVelocity(vectorNormalizado);
            Animaciones("RUNNING");
        }else if(Vector2.Distance(transform.position, posicion) < rangoDisparo)
        {
            playerMovementRB2D.SetVelocity(Vector3.zero);
            Animaciones("IDLE");
        }

        if(posicionEnemigo.position.x < transform.position.x)transform.localScale = new Vector3(-1, 1, 1);
        else if(posicionEnemigo.position.x > transform.position.x)transform.localScale = new Vector3(1, 1, 1);
        
    }

    void Animaciones(string nuevoEstado)
    {
        if(nuevoEstado == estadoActual)return;

        rebelAnim.Play(nuevoEstado);

        estadoActual = nuevoEstado;
    }

    void InvertirSprite()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.y);
    }
    void Muerte()
    {
        if(unidadMuerta)return;
        
        Animaciones("DEATH");
        gameObject.transform.Find("Weapon").gameObject.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = false;
        unidadMuerta = true;
        GetComponent<Rebel_Logic>().enabled = false;
    }
    public void TakeDamage(int damage)
    {
        vida -= damage;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }
}
