using UnityEngine;
public class PlayerController : MonoBehaviour
{ 
    public Rigidbody rb;  
    public Transform cam; //NEED REF TO CAMERA 
    public float speed = 5f;
    public float turnSmoothTime = 0.1f; 
    float turnSmoothVelocity; 
    public PlayerCollision PlayerCollision; 


    // MOVEMENT
    public bool isWalking = false;
    public bool isRunning = false; 
    public float jumpSpeed = 140f; 
    public bool grounded; 
    // MOVEMENT
    void Update()
    {
        // SHOOTING PROJECTILE 
        
        float horizontal = Input.GetAxisRaw("Horizontal"); // USING ARRROW KEYS. a = -1, d = 1 
        float vertical = Input.GetAxisRaw("Vertical"); // USING AROW KEYS. w= 1 s = -1 
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // NORMALIZED BC WE DO NOT WANT TO GO FASTER WHEN PRESSING TWO KEYS AT ONCE 
        // WE ARE MAKING THIS VECTOR SHORTER WITH MAGNITUDE = 1, but with same direction. 
        // THIS IS ESSENTIALLY A UNIT VECTOR 

        if(direction.magnitude >= 0.1f) // if >= 0.1f, THIS MEANS WE ARE GETTING SOME INPUT TO MOVE 
        {
            
            
            if (Input.GetKey("left shift"))
            {
                isRunning = true; 
                isWalking = true; // SO FOR isRunning to work WE NEED isWalking as a prequisite. 
                speed = 1.5f; // CHANGE TO SPRINT SPEED 

            }
            if (!Input.GetKey("left shift"))
            {
                isRunning = false;
                isWalking = true; // SET isWALKING TO TRUE 
                speed = 1f; // CHANGE TO Walk Speed 
            }
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

            rb.AddForce(moveDir.normalized * speed); // CONTROLLER.MOVE ACTIVATES DIR. MAKES PLAYER MOVE ALONG THE VECTOR DIR 
            
            
            // TIME DELTATIME MAKES IT FRAMERATE INDEPENDENT 
            

        }
        if(direction.magnitude == 0) 
        {
            isRunning = false; // THESE ARE THE CASES FOR CHARACTER TO BE IDLE 
            isWalking = false;    
        }

        if (Input.GetKeyDown(KeyCode.Space) && PlayerCollision.grounded == true)
            {
                Vector3 jumpForce = new Vector3(0, 0, 0);
                jumpForce.y += jumpSpeed;

                rb.AddForce(jumpForce );  
                PlayerCollision.grounded = false; 
            }

        
        }
            
}
