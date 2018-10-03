using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	private Rigidbody2D GoodGuy;

	//Particles
	public GameObject DeathPartical;
	public GameObject RespawnParticle;

	//Respawn Delay
	public float RespawnDelay;

	//Point Penalty on Death
	public int PointPenaltyOnDeath;

	//Store Gravity Value
	private float GravityValue;

	// Use this for initialization
	void Start () {
		GoodGuy = FindObjectOfType<Rigidbody2D>();
	}
	public void RespawPlayer(){
		StartCoroutine ("RespawnGoodGuyCo");
	}
	public IEnumerator RespawnPlayeryCo(){
		//Generate Death Partical
		Instantiate (DeathParticle, GoodGuy.transform.position, GoodGuy.transform.rotation);
		//Hide
		//Pc.enabled = false
		GoodGuy.GetComponent<Renderer>().enabled = false;
		//Gravity Reset
		GravityStore = GoodGuy.GetComponent<Rigidbody2D>().gravityScale;
		GoodGuy.GetComponent<Rigidbody2D>().gravityScale =0f;
		GoodGuy.GetComponent<Rigidbody2D>().velocity.Vector2.zero;
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
		GoodGuy.GetComponent<Renderer>().enabled = true;
		//Spawn GoodGuy
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
}
