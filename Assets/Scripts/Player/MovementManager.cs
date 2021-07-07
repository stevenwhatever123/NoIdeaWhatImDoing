using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField]
    CharacterController controller;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float speed = 11f;

    [SerializeField]
    float gravity = -30f;

    Vector3 verticalVelocity = Vector3.zero;

    Vector2 horizontalInput;

    [SerializeField]
    LayerMask groundMask;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    float groundDistance = 0.4f;

    bool isGrounded;

    void Update()
    {
        bool jumpPressed = false;

        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && verticalVelocity.y < 0)
        {
            verticalVelocity.y = -2f;
        }

        verticalVelocity.y += gravity * Time.deltaTime;

        controller.Move(verticalVelocity * Time.deltaTime);
    }

    public void RecieveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
        animator.SetInteger("VelocityX", (int) Mathf.Ceil(horizontalInput.x));
        animator.SetInteger("VelocityY", (int) Mathf.Ceil(horizontalInput.y));
        //print(horizontalInput);
    }
}
