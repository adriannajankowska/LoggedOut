using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    public GameObject phoneOnTheGround;
    public GameObject phoneInTheHand;

    public float downTime = 0f;
    public float countDown = 5.0f;
    public bool ready = false;

    void Start()
    {
        phoneInTheHand.SetActive(false);
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isWKeyPressed = Input.GetKey("w");
        bool isLKeyPressed = Input.GetKey("l");
        bool isEKeyPressed = Input.GetKey("e");

        // walking animation controller
        if (!isWalking && isWKeyPressed)
        {
            animator.SetBool("isWalking", true);
        }

        if (!isWKeyPressed)
        {
            animator.SetBool("isWalking", false);
        }

        //looking at the phone animation controller
        if (!isWalking && isLKeyPressed)
        {
            animator.SetBool("isLookingAt", true);
        }

        if (!isLKeyPressed)
        {
            animator.SetBool("isLookingAt", false);
        }
        if (!isWalking && isEKeyPressed && ready == false)
        {
            animator.SetBool("isPickingUp", true); 
            downTime += Time.deltaTime;
            if(downTime >= countDown)
                ready = true;
        }
        if (ready == true)
        {
            phoneOnTheGround.SetActive(false);
            phoneInTheHand.SetActive(true);
        }

        if (!isEKeyPressed)
        {
            downTime = 0f;
            animator.SetBool("isPickingUp", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enlightment")
            phoneOnTheGround.SetActive(true);
    }

}
