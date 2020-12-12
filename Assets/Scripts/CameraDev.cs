using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class CameraDev : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] int off;
    
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x + off, transform.position.y, transform.position.z);
    }
        

}
