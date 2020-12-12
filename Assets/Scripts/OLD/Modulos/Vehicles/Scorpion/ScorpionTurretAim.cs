using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ScorpionTurretAim : MonoBehaviour
{
    public Vector3 gunEndPointPosition;
    Transform aimGunEndPointTransform;
    public GameObject scorpionShellPrefab;
    private Quaternion rotacion;
    public Vector3 aimDirection;
    int contador;
    

    void Awake ()
    {
        aimGunEndPointTransform = gameObject.transform.Find("GunEndPointPosition");
        
    }

    
    
    void Update ()
    {
        HandleAiming();
        HandleShooting();
    }

    void HandleAiming()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        aimDirection = (mousePosition - transform.position).normalized;
        rotacion = Quaternion.Euler(aimDirection);
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        if(angle < 45 && angle > -20)
        {
            transform.eulerAngles = new Vector3 (0, 0, angle);
        }
        
    }

    void HandleShooting()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        if(Input.GetMouseButtonDown(0))
        {
            contador++;
            GameObject scorpionShell = Instantiate(scorpionShellPrefab, aimGunEndPointTransform.position, Quaternion.identity);
            scorpionShell.name = "Scorpion Shell " + contador;
            
            
        }
    }

    
}

