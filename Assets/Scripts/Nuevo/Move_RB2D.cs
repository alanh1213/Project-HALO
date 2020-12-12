using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_RB2D : MonoBehaviour
{
    public float moveSpeed;

    public Vector3 velocityVector;
    Rigidbody2D rb2d;
    
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity (Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }

    private void FixedUpdate()
    {
        rb2d.velocity = velocityVector * moveSpeed;
    }
}
