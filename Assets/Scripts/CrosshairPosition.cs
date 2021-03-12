using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairPosition : MonoBehaviour
{
    void Update()
    {
        transform.position = Input.mousePosition;        
    }
}
