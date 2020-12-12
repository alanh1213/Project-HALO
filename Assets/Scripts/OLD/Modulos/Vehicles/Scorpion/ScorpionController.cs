using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionController : MonoBehaviour
{
    public bool playerInside;
    float horizontalMove, verticalMove;
    PlayerMovementRB2D scripDeMovimiento;
    GameObject player;
    Rigidbody2D rb2d;
    Animator anim;
    public GameObject luz1, luz2;
    void Awake()
    {
        scripDeMovimiento = GetComponent<PlayerMovementRB2D>();
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    

    
    void Update()
    {
        if(playerInside)
        {
            StartCoroutine("ArranquedeMotor");

        } else if (!playerInside)
        {
            StopCoroutine("ArranquedeMotor");
            Exit();
        }


        if(horizontalMove == 0 && verticalMove == 0 && Input.GetKeyDown(KeyCode.R) && playerInside == true)
        {
            playerInside = !playerInside;
        }
    }

    void PlayerInside()
    {
        //MOVIMIENTO DE PLAYER:
        
        luz1.SetActive(true);
        luz2.SetActive(true);
        GetComponent<PlayerMovementRB2D>().enabled = true;
        gameObject.transform.Find("Chasis").gameObject.transform.Find("Torreta").GetComponent<ScorpionTurretAim>().enabled = true;
        player.SetActive(false);
        rb2d.constraints = RigidbodyConstraints2D.None;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        Vector3 moveVector = new Vector3(horizontalMove, verticalMove).normalized;
        scripDeMovimiento.SetVelocity(moveVector);
        player.transform.position = new Vector3(transform.position.x, transform.position.y - 4, transform.position.z);
        
    }

    void Exit()
    {
        GetComponent<PlayerMovementRB2D>().enabled = false;
        gameObject.transform.Find("Chasis").gameObject.transform.Find("Torreta").GetComponent<ScorpionTurretAim>().enabled = false;
        luz1.SetActive(false);
        luz2.SetActive(false);
        player.SetActive(true);
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.SetBool("on", false);
    }

    IEnumerator ArranquedeMotor()
    {
        Debug.Log("Corrutina incializada");
        player.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        luz1.SetActive(true);
        luz2.SetActive(true);
        anim.SetBool("on", true);
        GetComponent<PlayerMovementRB2D>().enabled = true;
        gameObject.transform.Find("Chasis").gameObject.transform.Find("Torreta").GetComponent<ScorpionTurretAim>().enabled = true;
        rb2d.constraints = RigidbodyConstraints2D.None;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        Vector3 moveVector = new Vector3(horizontalMove, verticalMove).normalized;
        scripDeMovimiento.SetVelocity(moveVector);
        player.transform.position = new Vector3(transform.position.x, transform.position.y - 4, transform.position.z);


        //ANIMACIONES:
        if (horizontalMove != 0 || verticalMove != 0)
            {
                anim.SetBool("moving", true);
                
                
                if(Input.GetMouseButtonDown(0))
                {
                    anim.Play("ScorpionMovingSHOT");
                }
                
            } else
            {
                anim.SetBool("moving", false);
                anim.SetFloat("direction", 0);
                if(Input.GetMouseButtonDown(0))
                {
                    anim.Play("ScorpionIDLESHOT");
                    
                }
                
            }


            if(horizontalMove > 0 || verticalMove > 0)
            {
                anim.SetFloat("direction", 1);
            } else if (horizontalMove < 0 || verticalMove < 0)
            {
                anim.SetFloat("direction", -1);
            }
        
    }
    
}
