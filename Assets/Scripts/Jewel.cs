using UnityEngine;
using System.Collections;

public class Jewel : MonoBehaviour {

	PlayerController player;

	void Start(){
		player = FindObjectOfType<PlayerController>();
	}

	void FixedUpdate(){
		gameObject.transform.Translate(Vector3.left * 0.05f);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player" && player.hasCrate == false){
			player.HasCrate();
		}
		player.GetComponent<Rigidbody2D>().mass += 0.25f;
		player.crateCount ++;
		if (player.crateCount >= 2){
			player.currentCrateCounter.GetComponent<TextMesh>().text = "x" + player.crateCount;
		}
		Destroy(gameObject);

	}
}
