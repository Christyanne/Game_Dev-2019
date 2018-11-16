using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class MarshmallowShooter : MonoBehaviour {
	public float Speed;
	public float Timeout;
	public GameObject GoodGuy;
	public GameObject EnemyDeath;
	public int PointsForKill;

	// Use this for initialization
	void Start () {
		GoodGuy = gameObject.Find("GoodGuy");
		EnemyDeath = Resources.Load("Prefabs/DeathParticle");
		ProjectileParticle = Resources;Load("Prefabs/Respawn_Ps") as GameObject;
		if(GoodGuy.transform.localScale.x < 0)
			Speed = -Speed;	
		
		//Destroy Projectile after x seconds
		Destroy(gameObject,Timeout);	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Enemy"){
			Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			ScoreManager.AddPoints (PointsForKill);
		}
		//Instantiate(EnemyDeath, transform.position, transform.rotation);
		Destroy (GameObject);
	}	
		void OnCollisionEnter2D(Collision2D other){

		Instantiate(ProjectileParticle, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}	
