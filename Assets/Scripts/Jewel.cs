using UnityEngine;
using System.Collections;

public class Jewel : MonoBehaviour {

	PlayerController player;
	public AudioClip jewelPickup;

	void Start(){
		player = FindObjectOfType<PlayerController>();
	}

	void FixedUpdate(){
		gameObject.transform.Translate(Vector3.left * 0.05f);
	}

	void OnTriggerEnter2D(Collider2D col){
		player.GetComponent<AudioSource>().PlayOneShot(jewelPickup, 1f);

		if (col.gameObject.tag == "Player" && player.hasCrate == false){
			player.HasCrate();
		}
		player.GetComponent<Rigidbody2D>().mass += 0.25f;
		col.gameObject.transform.GetChild(0).GetComponent<Crate>().crateCount ++;
		if (col.gameObject.transform.GetChild(0).GetComponent<Crate>().crateCount >= 2){
			player.currentCrateCounter.GetComponent<TextMesh>().text = "x" + col.gameObject.transform.GetChild(0).GetComponent<Crate>().crateCount;
		}
		Destroy(gameObject);

	}
}
