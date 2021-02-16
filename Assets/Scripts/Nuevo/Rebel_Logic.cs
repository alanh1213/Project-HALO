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
    [SerializeField] private float fireRate = 1f;
    private float startFireRate = 1f;
    [SerializeField] private GameObject disparoGO;
    BrazoAIMController brazoAIM;
    void Awake()
    {
        playerMovementRB2D = GetComponent<PlayerMovementRB2D>();
        rebelAnim = GetComponent<Animator>();
        weaponAnim = gameObject.transform.Find("Weapon").transform.Find("Weapon_Sprite").GetComponent<Animator>();
        puntoDisparo = gameObject.transform.Find("Weapon").transform.Find("Origen_Disparo").transform;
        posicionEnemigo = transform;
        armaTransform = transform.Find("Weapon").transform;
        brazoAIM = transform.Find("Weapon").GetComponent<BrazoAIMController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        fireRate -= Time.deltaTime;


        if(vida > 0)
        {
            BuscarEnemigo();
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
            weaponAnim.SetBool("enemySpotted", true);
            posicionEnemigo = enemigo.transform;
            ApuntarA(posicionEnemigo.position);
            MoverseHacia(posicionEnemigo.position);
            return;
        }else
        {
            weaponAnim.SetBool("enemySpotted", false);
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
            Disparar();
        }

        if(posicionEnemigo.position.x < transform.position.x)transform.localScale = new Vector3(-1, 1, 1);
        else if(posicionEnemigo.position.x > transform.position.x)transform.localScale = new Vector3(1, 1, 1);
        
    }
    void ApuntarA(Vector3 posicion)
    {
        Vector3 vectorNormalizado = (posicion - transform.position).normalized;
        float angulo = Mathf.Atan2(vectorNormalizado.y, vectorNormalizado.x) * Mathf.Rad2Deg;

        brazoAIM.ApuntarA(angulo);
    }
    void Disparar()
    {
        if(fireRate <= 0)
        {
            GameObject bala = Instantiate(disparoGO, puntoDisparo.position, armaTransform.rotation);
            if(posicionEnemigo.position.x > transform.position.x)bala.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            else if(posicionEnemigo.position.x < transform.position.x)bala.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            bala.GetComponent<Move_RB2D>().SetVelocity(NormalizarVector(posicionEnemigo.position));

            fireRate = startFireRate;
        }
    }

    Vector3 NormalizarVector(Vector3 vector)
    {
        Vector3 vectorNormalizado = (vector - transform.position).normalized;
        return vectorNormalizado;
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

        MoverseHacia(this.transform.position);
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
