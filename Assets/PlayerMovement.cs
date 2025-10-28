using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Vector3 moveInput;
    private Vector2 mouseInput;
    public float walkSpeed = 500;
    public float sprintSpeed = 750;
    public float turnRate = 5;
    private float move;
    public float jumpSpeed = 300;
    public Rigidbody rb;

    void Update()
    {

        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        movePlayer();
        turnPlayer();
        jumpPlayer();
    }

    private void movePlayer()
    {
        if (Input.GetKey("left shift"))
        {
            move = sprintSpeed;
        }
        else
        {
            move = walkSpeed;
        }
        Vector3 moveVector = transform.TransformDirection(moveInput) * move * Time.fixedDeltaTime;
        rb.linearVelocity = new Vector3(moveVector.x, rb.linearVelocity.y, moveVector.z);
    }

    private void turnPlayer()
    {
        transform.Rotate(0f, mouseInput.x * turnRate, 0f);
    }

    private void jumpPlayer()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
        }
    }
}