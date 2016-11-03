﻿using UnityEngine;
using System.Collections;

public class BuildingBehavior : MonoBehaviour {

	PlayerController player;

	void Start(){
		player = FindObjectOfType<PlayerController>();
	}

	void FixedUpdate(){
		gameObject.transform.Translate(Vector3.left * 0.05f);
	}

	void OnTriggerEnter2D(Collider2D col){
		player.isDamaged = true;
	}

	void OnTriggerExit2D(Collider2D col){
		player.isDamaged = false;
	}
}
