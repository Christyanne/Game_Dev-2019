using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour { 
    // Player Movement Variables
	public int MoveSpeed;
	public float JumpHeight;
	private bool doubleJump;
	public float moveVelocity;

	// Player grounded variables
	public Transform groundcheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	// Use this for initialization
	void Start (){
	 }

	void FixedUpdate () {
		grounded = Physics2D.OverLapCircle(groundCheck.position, groundCheckRarius, whatIsGround);
	 }
	// Update is called once per frame
	void Update () {
		
		//This code makes the character jump
		if (Input.GetKeyDown (KeyCode.Space)&& grounded){
                 Jump();

		}
    
        //Double jump code
       if (grounded)
	            doubleJump = false;

	   if (Input.GetKeyDown (KeyCode.Space)&& !grounded){
                Jump();
				doubleJump = true;
	   }   
       //Non-Slide Player
	   moveVelocity = 0f;

	    //This code makes the character move from side to side using A&D keys
		if (Input.GetKey (KeyCode.D)){
                //GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody>().velocity.y);


		}
        if (Input.GetKey (KeyCode.A)){
                //GetComponent<Rightbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

		
		}   
	}
		
	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);

		
	}
}