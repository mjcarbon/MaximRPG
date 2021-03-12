using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Rigidbody rb; 
    void OnCollisionEnter(Collision collisionInfo)  // VOID BASICALLY MEANS "WHEN". SO WHEN OBJECT COLLIDES W/ SOMETHING 
    {
        if (collisionInfo.collider.tag == "Floor")
        {
            Debug.Log("FloorGang");
        }
    }  
}
