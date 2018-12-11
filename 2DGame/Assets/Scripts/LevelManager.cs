using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	public Rigidbody2D GoodGuy_2;
	public GameObject GoodGuy3;

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
		GoodGuy_2 = GameObject.Find("GoodGuy_2").GetComponent<Rigidbody2D>();
		GoodGuy3 = GameObject.Find("GoodGuy_2");
		// GoodGuy = FindObjectOfType<Rigidbody2D>();
	}
	public void RespawnPlayer(){
		StartCoroutine ("RespawnGoodGuy_2Co");
	}
	public IEnumerator RespawnGoodGuy_2Co(){
		//Generate Death Partical
		Instantiate (DeathPartical, GoodGuy_2.transform.position, GoodGuy_2.transform.rotation);
		//Hide
		//Pc.enabled = false
		GoodGuy3.SetActive(false);
		GoodGuy_2.GetComponent<Renderer>().enabled = false;
		//Gravity Reset
		GravityStore = GoodGuy_2.GetComponent<Rigidbody2D>().gravityScale;
		GoodGuy_2.GetComponent<Rigidbody2D>().gravityScale =0f;
		GoodGuy_2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		//Point Penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		//Debug Mesage
		Debug.Log ("GoodGuy Respawn");
		//Respawn Delay
		yield return new WaitForSeconds (RespawnDelay);
		//Gravity Restore
		GoodGuy_2.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		//Match GoodGuys transform position
		GoodGuy_2.transform.position = CurrentCheckPoint.transform.position;
		//Show GoodGuy
		//GoodGuy.enable = true;
		GoodGuy3.SetActive(true);
		GoodGuy_2.GetComponent<Renderer>().enabled = true;
		//Spawn GoodGuy
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
}
