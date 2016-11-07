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

			gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
			gameObject.GetComponent<BoxCollider2D>().enabled = false;


			player.GetComponent<AudioSource>().PlayOneShot(buildingCollide, 0.5f);
			player.GetComponent<Animator>().Play("Damaged");

			if(col.gameObject.transform.GetChild(0).GetComponent<Crate>().crateCount > 0){
				FindObjectOfType<UIManager>().AddScore(-2 * col.gameObject.transform.GetChild(0).GetComponent<Crate>().crateCount);
			} else {
				FindObjectOfType<UIManager>().AddScore(-2);

			}

			player.DropCrate();
		}

		if (col.gameObject.tag == "Crate"){
			Destroy(col.gameObject);
		}
	}
}
