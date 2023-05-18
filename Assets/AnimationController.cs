using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Get a reference to the Animator component
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Add logic to trigger animations based on your game conditions

        // Example: Trigger the "Jump" animation when the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
    }
}
