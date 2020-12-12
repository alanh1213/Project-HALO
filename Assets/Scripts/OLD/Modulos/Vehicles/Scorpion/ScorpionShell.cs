using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ScorpionShell : MonoBehaviour
{
    Quaternion rotacion;
    Rigidbody2D rigidbody;
    public GameObject explosionPrefab, blueBlood;
    Vector3 mousePosition;
    [SerializeField] Vector3 targetPosition;
    PlayerMovementRB2D movementScript;
    public GameObject torreta;
    public int speed;
    float angle;
    ScorpionTurretAim referenciaScript;
    public int damage;
    int contador;
    public bool rocket;
    void Awake()
    {
        torreta = GameObject.Find("Torreta");
        rigidbody = GetComponent<Rigidbody2D>();
        referenciaScript = torreta.GetComponent<ScorpionTurretAim>();
        movementScript = GetComponent<PlayerMovementRB2D>();
    }
    void Start()
    {
        transform.rotation = torreta.transform.rotation;
        
        targetPosition = referenciaScript.aimDirection;
        Quaternion.LookRotation(targetPosition);

        rotacion = Quaternion.Euler(targetPosition);
        angle = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        movementScript.SetVelocity(targetPosition);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other)
        {
            IDamagable enemy = other.transform.GetComponent<IDamagable>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            } 
            
        }
        //Si la bala es un cohete:
        if(rocket) Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        if(other.CompareTag("Covenant") || other.CompareTag("Ground")) Destroy(gameObject);
        
    }
}
