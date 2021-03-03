using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator; // Animator ref variable 
    // Start is called before the first frame update
    public PlayerController player; 
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player.isWalking == true)
        {
            animator.SetBool("isWalking", true); // ANIMATOR IS BUILT IN UNITY COMPONENT 
        }
        if (player.isWalking == false)
        {
            animator.SetBool("isWalking", false); // ANIMATOR IS BUILT IN UNITY COMPONENT 
        }
        if (player.isRunning == true)
        {
            animator.SetBool("isRunning", true);
        }
        if (player.isRunning == false)
        {
            animator.SetBool("isRunning", false);
        }
        if (player.isJumping == true)
        {
            Invoke("Jump", 5);
        }
        if (player.isJumping == false)
        {
            Invoke("Jump", 5);
        }
    }

    void Jump()
    {
        if (player.isJumping == true)
        {
            animator.SetBool("isJumping", true);
        }
        if (player.isJumping == false)
        {
            animator.SetBool("isJumping", false);
        }
    }
}
