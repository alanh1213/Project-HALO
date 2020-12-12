using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt_Logic : MonoBehaviour, IDamagable
{
    [SerializeField] private float distanciaAlEnemigo = 20f;
    [SerializeField] private int numeroDeVida = 300;
    [SerializeField] private float radioDeDeteccion = 50f;
    [SerializeField] private LayerMask whatIsEnemy;
    private string currentAnimation;
    private Vector3 posicionEnemigo;
    GameObject brazoGO;
    Animator brazoAnimator;
    Move_RB2D move_RB2D;

    //-------------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------------

    private void Awake() 
    {
        move_RB2D = GetComponent<Move_RB2D>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        brazoGO = gameObject.transform.Find("Brazo_Grunt").gameObject;
        brazoAnimator = brazoGO.gameObject.transform.Find("brazo").GetComponent<Animator>();
    }
    void Start()
    {
        npcMode = NPCMode.vivo;
        posicionEnemigo = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch(npcMode)
        {
            case(NPCMode.vivo):
                BuscandoObjetivo();
                if(Vector2.Distance(transform.position, posicionEnemigo) < distanciaAlEnemigo)
                {
                    MoverseA(transform.position);
                    brazoAnimator.SetBool("moving", false);
                    ChangeAnimationState(IDLE);
                    ApuntarA(posicionEnemigo);
                }else
                {
                    MoverseA(posicionEnemigo);
                    brazoAnimator.SetBool("moving", true);
                    ChangeAnimationState(MOVING);
                    ApuntarA(posicionEnemigo);
                }

            break;
            case(NPCMode.muerto):
                MoverseA(transform.position);
            break;
        }
        

        if(numeroDeVida <= 0 && npcMode == NPCMode.vivo)
        {
            Muerte();
            npcMode = NPCMode.muerto;
        }
    }


    void BuscandoObjetivo()
    {
        Collider2D enemigo = Physics2D.OverlapCircle(transform.position, radioDeDeteccion, whatIsEnemy);
        if(enemigo != null)
        {
            Debug.Log("DETECTADO HUMANO");
            posicionEnemigo = enemigo.transform.position;
            brazoAnimator.SetBool("enemySpotted", true);
        }
        else
        {
            brazoAnimator.SetBool("enemySpotted", false);
        }
        
    }


    void MoverseA(Vector3 posicion)
    {
        Vector3 vectorDeMovimiento = (posicion - transform.position).normalized;
        move_RB2D.SetVelocity(vectorDeMovimiento);
    }

    public void TakeDamage (int damage)
    {
        numeroDeVida -= damage;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioDeDeteccion);
    }

    public void ApuntarA(Vector3 posicionEnemigo)
    {
        

        Vector3 aimDirection = (posicionEnemigo - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        brazoGO.transform.eulerAngles = new Vector3 (0, 0, angle);

        if(angle < 90 && angle > -90)
        {
            Vector3 playerScale = new Vector3 (1, 1, 1);
            brazoGO.transform.localScale = playerScale;
        } else if (angle > 90 || angle < -90)
        {
            Vector3 playerScale = new Vector3 (-1, -1, 1);
            brazoGO.transform.localScale = playerScale;
        }
    }
    void Muerte()
    {
        float numeroRandom = Random.Range(-2f, 2.1f);
        if(numeroRandom > 0)ChangeAnimationState(DEATH);
        else ChangeAnimationState(DEATH2);
        gameObject.transform.Find("Brazo_Grunt").gameObject.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
    }

    void ChangeAnimationState(string newAnimationState)
    {
        if(currentAnimation == newAnimationState)return;

        animator.Play(newAnimationState);

        currentAnimation = newAnimationState;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------------------
    const string IDLE = "IDLE";
    const string WALK = "WALK";
    const string MOVING = "MOVING";
    const string DEATH = "DEATH";
    const string DEATH2 = "DEATH2";

    public enum NPCMode {vivo, muerto}
    NPCMode npcMode;
    Rigidbody2D rb2d;
    Animator animator;
}
