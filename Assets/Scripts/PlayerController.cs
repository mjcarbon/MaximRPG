using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public CharacterController controller; // ACCESS TO PLAYER MOVEMENT OR CHARACTER CONTROLLER AKA "MOTOR"
    public Transform cam; //NEED REF TO CAMERA 
    public bool isWalking = false;
    
    public float speed = 6f; // SPEED OF MOVEMENT 
    public float turnSmoothTime = 0.1f; 
    float turnSmoothVelocity; 

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // USING ARRROW KEYS. a = -1, d = 1 
        float vertical = Input.GetAxisRaw("Vertical"); // USING AROW KEYS. w= 1 s = -1 
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // NORMALIZED BC WE DO NOT WANT TO GO FASTER WHEN PRESSING TWO KEYS AT ONCE 
        // WE ARE MAKING THIS VECTOR SHORTER WITH MAGNITUDE = 1, but with same direction. 
        // THIS IS ESSENTIALLY A UNIT VECTOR 

        if(direction.magnitude >= 0.1f) // if >= 0.1f, THIS MEANS WE ARE GETTING SOME INPUT TO MOVE 
        {
            isWalking = true; // SET isWALKING TO TRUE 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; 
            // THIS RETURNS THE ANGLE THAT THE VECTOR IS RELATIVE TO Y AXIS GOING COUNTER CLOCKWISE 
            
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            // MAKES OUR ROTATION SMOOTHER. 

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //Quaternion.Euler HAS THREE NUMS TO ROTATE with BUT WE JUST WANT TO ROTATE 
            //AROUND THE Y AXIS WITH THE ANGLE 
            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
            // WE CHANGE THIS FROM A ROTATION INTO A DIRECTION BY MULTIPLYING IT WITH VECTOR3.FORWARD 
            // targetAngle HELPS TAKE INTO ACCOUNT THE ROTATION OF OUR CAMERA 

            controller.Move(moveDir.normalized * speed * Time.deltaTime); // CONTROLLER.MOVE ACTIVATES DIR. MAKES PLAYER MOVE ALONG THE VECTOR DIR 
            // TIME DELTATIME MAKES IT FRAMERATE INDEPENDENT 
        } 
    }
}
