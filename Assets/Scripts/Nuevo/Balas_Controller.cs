using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas_Controller : MonoBehaviour
{
    [SerializeField] private GameObject end_GFX;
    [SerializeField] private int damage = 25;
    void Update()
    {
        Destroy(gameObject, 10f);
    }

    
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Collider2D collider = collision.collider;
        if(collider.GetComponent<IDamagable>() != null)collider.transform.GetComponent<IDamagable>().TakeDamage(damage);
        Instantiate(end_GFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        Instantiate(end_GFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    
}
