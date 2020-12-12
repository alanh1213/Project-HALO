using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    [SerializeField] private float tiempo = 10f;

    private void Update()
    {
        Destroy(gameObject, tiempo);
    }
}
