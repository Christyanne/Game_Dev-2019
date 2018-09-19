using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {
    // Player Movement Variables
	public int MoveSpeed;
	public float JumpHeight;

	// Player grounded variables
	public Tranform groundcheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround
	private bool grounded;

	// Use this for initialization
	void Start () {
		
	}
	

	void FixedUpdate () {
		grounded = Physics2D.OverLapCircle(groundCheck.position, groundCheckRarius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
