using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator playerAnimator;
    PlayerMovementRB2D scripDeMovimiento;
    void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        scripDeMovimiento = GetComponent<PlayerMovementRB2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoJugador();
        if(Input.GetKey(KeyCode.Mouse0))
        {
            playerAnimator.SetBool("fire", true);
        }else
        {
            playerAnimator.SetBool("fire", false);
            
        }
    }

    void Disparar()
    {
        
    }

    void MovimientoJugador()
    {
        
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        Vector3 moveVector = new Vector3(horizontalMove, verticalMove).normalized;
        scripDeMovimiento.SetVelocity(moveVector);

        //CONTROLES DE ANIMACIONES
        if (horizontalMove != 0 || verticalMove != 0)
        {
            playerAnimator.SetBool("moving", true);
            if(horizontalMove > 0)
            {
                transform.localScale = new Vector3(1,1,1);
            }else if(horizontalMove < 0)
            {
                transform.localScale = new Vector3(-1,1,1);
            }

        } else if (horizontalMove == 0 || verticalMove == 0)
        {
            playerAnimator.SetBool("moving", false);
        }

        
    }
}
