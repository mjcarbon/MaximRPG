using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; 
    public Vector3 offset; 
    private float currentZoom = 10f; 
    public float zoomSpeed = 4f; 
    public float minZoom = 5f; 
    public float maxZoom = 15f; 
    
    public float speedH = 2f; // THE HORIZONTAL SPEED OF ROTATION 
    private float yaw = 0f; // YAW IS THE VALUE THAT WE USE TO ROTATE 
    void Update()
    {
        
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;  // TO GET ANY CHANGES IN OUR SCROLLWHEEL. NOTE: CAN WORK W/O ZOOMSPEED  
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        
        yaw += speedH * Input.GetAxis("Mouse X"); // YAW WILL BE THE SPEED + HOW MUCH OUR MOUSE MOVES ON X-AXIS 
       

        transform.position = player.position + offset * currentZoom;  
        transform.LookAt(player.position + Vector3.up);
        transform.RotateAround(player.position, Vector3.up, yaw);
    }
}
