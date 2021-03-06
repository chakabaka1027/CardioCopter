﻿using UnityEngine;
using System.Collections;

public class CrateTriggerZone : MonoBehaviour {

	public GameObject buildingFireworks;
	public AudioClip fireworksSFX;

	PlayerController player;



	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Crate"){

			

			GameObject currentFireworks = Instantiate(buildingFireworks, gameObject.transform.position, Quaternion.Euler(-90, 0, 0)) as GameObject;
			currentFireworks.transform.parent = gameObject.transform;
			Destroy(currentFireworks, 10);

			if(col.gameObject.GetComponent<Crate>().crateCount >= 5){

				StartCoroutine(FindObjectOfType<UIManager>().Celebration());
			}

			FindObjectOfType<UIManager>().AddScore((int)Mathf.Pow(2, col.gameObject.GetComponent<Crate>().crateCount)) ;

			Destroy(col.gameObject);

//			yield return new WaitForSeconds(1);


			player.GetComponent<AudioSource>().PlayOneShot(fireworksSFX, 0.5f);
		}

		if(col.gameObject.tag == "Player"){
			gameObject.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
			gameObject.GetComponent<BoxCollider2D>().enabled = false;


			player.DropCrate();

			player.GetComponent<AudioSource>().PlayOneShot(FindObjectOfType<BuildingBehavior>().buildingCollide, 0.5f);
			player.GetComponent<Animator>().Play("Damaged");

			if (col.gameObject.transform.childCount > 0 && col.gameObject.transform.GetChild(0).GetComponent<Crate>().crateCount > 0){
				FindObjectOfType<UIManager>().AddScore((int)Mathf.Pow(2, col.gameObject.GetComponent<Crate>().crateCount) * -1);
			} else {
				FindObjectOfType<UIManager>().AddScore(-2);
			}
		}
	}


}
