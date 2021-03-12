using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 gravity = new Vector3(0, -9f, 0); 

    void Update()
    {
        controller.Move(gravity * Time.deltaTime);  
    }
}
