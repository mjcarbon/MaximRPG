using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator; // Animator ref variable 
    // Start is called before the first frame update
    public PlayerController player; 
    
    void Start()
    {
        animator.GetComponent<Animator>();
    }

    void Update()
    {
        if (player.isWalking == true)
        {
            animator.SetBool("isWalking", true); // ANIMATOR IS BUILT IN UNITY COMPONENT 
        }

    }
}
