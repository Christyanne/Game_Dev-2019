﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour { 
    // Player Movement Variables
	public int MoveSpeed;
	public float jumpHeight;
	private bool doubleJump;
	public float moveVelocity;

	// Player grounded variables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	public Animator animator;
	// Use this for initialization
	void Start (){
		animator.SetBool("isWalking", false);
		animator.SetBool("isJumping", false);
	} 
	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
	// Update is called once per frame
	void Update () {
		
		//This code makes the character jump
		if (Input.GetKeyDown (KeyCode.Space)&& grounded){
            Jump();
		}

        //doubleJump code
       if (grounded){
	        doubleJump = false;
			animator.SetBool("isJumping", false);
	   }
	   if (Input.GetKeyDown (KeyCode.Space)&& !doubleJump && !grounded){
            	Jump();
				doubleJump = true;
	   }   
    	//Non-Slide Player
	    moveVelocity = 0f;

	    //This code makes the character move from side to side using A&D keys
		if (Input.GetKey (KeyCode.D)){
            //GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = MoveSpeed;
			animator.SetBool("isWalking",true);
		}
		else if (Input.GetKey (KeyCode.D)){
			animator.SetBool("isWalking",false);
		}

        if (Input.GetKey (KeyCode.A)){
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -MoveSpeed;
			animator.SetBool("isWalking",true);
		}	
		else if (Input.GetKey (KeyCode.A)){
			animator.SetBool("isWalking",false);
		}
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

		//Player flip
		if (GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(5.5f,5.5f,1f);
		else if (GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3(-5.5f,5.5f,1f);

		   
    }	
		
	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		animator.SetBool("isJumping",true);
	}
}