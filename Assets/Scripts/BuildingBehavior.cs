using UnityEngine;
using System.Collections;

public class BuildingBehavior : MonoBehaviour {

	PlayerController player;
	public AudioClip buildingCollide;

	void Start(){
		player = FindObjectOfType<PlayerController>();
	}

	void FixedUpdate(){
		gameObject.transform.Translate(Vector3.left * 0.05f);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player"){
			player.GetComponent<AudioSource>().PlayOneShot(buildingCollide, 0.5f);
			player.GetComponent<Animator>().Play("Damaged");
			player.DropCrate();
		}

		if (col.gameObject.tag == "Crate"){
			Destroy(col.gameObject);
		}
	}
}
