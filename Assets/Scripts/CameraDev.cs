using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class CameraDev : MonoBehaviour
{
    [SerializeField] Transform objetivo;
    [SerializeField] private Vector3 offSet;
    [Range(1, 10)]
    [SerializeField] private float velocidadMovimiento;
    
    void FixedUpdate()
    {
        if(objetivo.position.x > -17.5f && objetivo.position.x < 235f)
        {
            SeguirObjetivo();
        }
    }

    void SeguirObjetivo()
    {
        Vector3 targetPosition = objetivo.position + offSet;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, velocidadMovimiento * Time.fixedDeltaTime);
        transform.position = new Vector3(smoothPosition.x, transform.position.y, transform.position.z);
    }
    [SerializeField] private bool cinemaMode;   

}
