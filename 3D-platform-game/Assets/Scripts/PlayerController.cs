﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float distToGrounded;

    private Rigidbody theRB;
    [SerializeField] LayerMask ground;


    private void Start()
    {
        //moveSpeed = 7;
        //jumpForce = 6;
        //distToGrounded = 1.1f;
         
        theRB = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && Grounded())
        {
            theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
        }
    }

    private bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGrounded, ground);
    }
}