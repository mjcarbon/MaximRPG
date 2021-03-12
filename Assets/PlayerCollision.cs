using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Rigidbody rb;
    public bool grounded; 
    void OnCollisionEnter(Collision collisionInfo)  // VOID BASICALLY MEANS "WHEN". SO WHEN OBJECT COLLIDES W/ SOMETHING 
    {
        if (collisionInfo.collider.tag == "Floor")
        {
            grounded = true; 
            Debug.Log("FloorGang");
        }
        else
        {
            grounded = false; 
        }
    }

    void Update()
    {
        if(grounded == false)
        {
            Vector3 gravity = new Vector3(0, -20f, 0);
            //rb.AddForce(gravity);
        }
    }  
}
