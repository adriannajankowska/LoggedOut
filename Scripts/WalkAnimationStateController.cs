using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WalkAnimationStateController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isWKeyPressed = Input.GetKey("w");

        if (!isWalking && isWKeyPressed)
        {
            animator.SetBool("isWalking", true);
        }

        if (!isWKeyPressed)
        {
            animator.SetBool("isWalking", false);
        }
    }
}

