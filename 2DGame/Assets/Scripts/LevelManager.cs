﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	public Rigidbody2D GoodGuy;
	public GameObject GoodGuy2;

	//Particles
	public GameObject DeathPartical;
	public GameObject RespawnParticle;

	//Respawn Delay
	public float RespawnDelay;

	//Point Penalty on Death
	public int PointPenaltyOnDeath;

	//Store Gravity Value
	private float GravityStore;

	// Use this for initialization
	void Start () {
		GoodGuy = GameObject.Find("GoodGuy").GetComponent<Rigidbody2D>();
		GoodGuy2 = GameObject.Find("GoodGuy");
		// GoodGuy = FindObjectOfType<Rigidbody2D>();
	}
	public void RespawnPlayer(){
		StartCoroutine ("RespawnGoodGuyCo");
	}
	public IEnumerator RespawnGoodGuyCo(){
		//Generate Death Partical
		Instantiate (DeathPartical, GoodGuy.transform.position, GoodGuy.transform.rotation);
		//Hide
		//Pc.enabled = false
		GoodGuy2.SetActive(false);
		GoodGuy.GetComponent<Renderer>().enabled = false;
		//Gravity Reset
		GravityStore = GoodGuy.GetComponent<Rigidbody2D>().gravityScale;
		GoodGuy.GetComponent<Rigidbody2D>().gravityScale =0f;
		GoodGuy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		//Point Penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		//Debug Mesage
		Debug.Log ("GoodGuy Respawn");
		//Respawn Delay
		yield return new WaitForSeconds (RespawnDelay);
		//Gravity Restore
		GoodGuy.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		//Match GoodGuys transform position
		GoodGuy.transform.position = CurrentCheckPoint.transform.position;
		//Show GoodGuy
		//GoodGuy.enable = true;
		GoodGuy2.SetActive(true);
		GoodGuy.GetComponent<Renderer>().enabled = true;
		//Spawn GoodGuy
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
}
