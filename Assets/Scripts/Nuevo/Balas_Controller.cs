using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas_Controller : MonoBehaviour
{
    private Move_RB2D move_RB2D;
    [SerializeField] private GameObject end_GFX;

    void Awake()
    {
        move_RB2D = GetComponent<Move_RB2D>();
    }

    void Start()
    {
        move_RB2D.SetVelocity(transform.right);
    }
    void Update()
    {
        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Instantiate(end_GFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(end_GFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    
}
