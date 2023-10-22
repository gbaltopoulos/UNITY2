using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WogGoZOOM : MonoBehaviour
{
    public float speed = 5;
    public float rotationspeed = 90;
    public float gravity = -20f;
    public float JumpSpeed = 15;

    CharacterController controller;
    Vector3 moveVelocity;
    Vector3 turnVelocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        var hinput = Input.GetAxis("Horizontal");
        var vinput = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveVelocity = transform.forward * speed * vinput;
            turnVelocity = transform.up * rotationspeed * hinput;
            if (Input.GetButtonDown("Jump"))
            {
                moveVelocity.y = JumpSpeed;
            }
        }
        moveVelocity.y += gravity * Time.deltaTime;
        controller.Move(moveVelocity * Time.deltaTime);
        transform.Rotate(turnVelocity * Time.deltaTime);
    }
}

