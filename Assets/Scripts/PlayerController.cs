using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10.0f;
    public Transform groundCheck;
    public LayerMask defineGround;
    public float jumpForce = 5;

    private Rigidbody2D rBody;
    private SpriteRenderer sRend;
    private Animator animator;

    private float groundCheckRadius = 0.3f;
    private bool isGrounded = false;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            animator.SetBool("Ground", false);
            rBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, defineGround);
        //Debug.Log("Grounded?" + isGrounded);

        animator.SetBool("Ground", isGrounded);

        //Pass vertical velocity to animator
        animator.SetFloat("vSpeed", rBody.velocity.y);

        float moveHoriz = Input.GetAxis("Horizontal");

        //Debug.Log("Horizontal value = " + moveHoriz);
        animator.SetFloat("Speed", Math.Abs(moveHoriz));

        rBody.velocity = new Vector2(moveHoriz * maxSpeed, rBody.velocity.y);

        if (moveHoriz > 0)
        {
            sRend.flipX = false;
        }else if (moveHoriz < 0)
        {
            sRend.flipX = true;
        }
	}
}
