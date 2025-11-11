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

    private bool jump;
    private bool grounded;

    void Update()
    {

        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        jump = jump || Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
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
        if (jump && grounded)
        {
            rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            jump = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}