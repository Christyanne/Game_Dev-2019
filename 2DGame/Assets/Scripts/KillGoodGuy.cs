using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoodGuy : MonoBehaviour {
	
	public LevelManager LevelManager;
	
	// Use this for initialization
	void Start () {
		LevelManager = FindObjectOfType <LevelManager>();
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "GoodGuy_2"){
			LevelManager.RespawnPlayer();
		}
	}
}
