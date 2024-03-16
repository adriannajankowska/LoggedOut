using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Camera camera;

    [Header("Movement Parameters")]
    public float speed = 2f;

    [Header("Jumping Parameters")]
    public float gravity = -9.81f;
    public float jumpHeight;

    [Header("Debug Parameters")]
    public Text debugText;

    public Vector3 moveDirection;
    public Vector3 move;
    Vector3 velocity;

    [Header("Headbob Parameters")]
    [SerializeField] private float walkBobSpeed = 14f;
    [SerializeField] private float walkBobAmount = 0.05f;
    private float defaultYPosition = 0;
    private float timer;

    private void Awake()
    {
    }

    void Update()
    {
        // jumping controller
        //if (controller.isGrounded && moveDirection.y < 0)   //added the "controller." part
        //{
        //    moveDirection.y = -2f;
        //    debugText.text = "Grounded";
        //    //if (Input.GetKeyDown(KeyCode.Space))
        //    //{
        //    //    moveDirection.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        //    //}

        //}
        //else
        //{
        //    debugText.text = "Not grounded";
        //}

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Mathf.Abs(move.x) > 0.1f || Mathf.Abs(move.z) > 0.1f)
        {
            // does this line not cause the camera jiggling in Town scene?
            defaultYPosition = camera.transform.localPosition.y;
            timer += Time.deltaTime * walkBobSpeed;
            camera.transform.localPosition = new Vector3(camera.transform.localPosition.x, defaultYPosition + Mathf.Sin(timer) * walkBobAmount, camera.transform.localPosition.z);
        }
    }
}
