using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour {

void OnztriggerEnter2D (Collider2D other) {

	if(other.name == "GoodGuy_2")
	{
		Debug.Log("Player Enters Death Zone");
		Destroy(other);
	}
}

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
