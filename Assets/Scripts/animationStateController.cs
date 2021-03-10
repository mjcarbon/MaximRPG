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
        if (player.jumpingFactor > 0f)
        {
            animator.SetBool("JumpPrep", true);
        }
        if (player.jumpingFactor == 0f)
        {
            animator.SetBool("JumpPrep", false);

        }
        if (player.inAir == true)
        {
            animator.SetBool("JumpLand", true);
        }
        if (player.inAir == false)
        {
            animator.SetBool("JumpLand", false);
        }
    }
}

