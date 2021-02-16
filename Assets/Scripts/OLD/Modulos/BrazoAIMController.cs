using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazoAIMController : MonoBehaviour
{
    public void ApuntarA(float angle)
    {
        transform.eulerAngles = new Vector3 (0, 0, angle);
        if(angle < 90 && angle > -90)
        {
            transform.localScale = new Vector3 (1, 1, 1);
        } else if (angle > 90 || angle < -90)
        {
            transform.localScale = new Vector3 (-1, -1, 1);
        }
    }
}
