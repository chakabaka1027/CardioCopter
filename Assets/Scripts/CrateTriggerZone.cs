using UnityEngine;
using System.Collections;

public class CrateTriggerZone : MonoBehaviour {

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
			FindObjectOfType<UIManager>().AddScore(2 * player.crateCount);
			player.crateCount = 0;
			Destroy(col.gameObject);
		}

		if(col.gameObject.tag == "Player"){
			gameObject.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
			gameObject.transform.GetComponent<BoxCollider2D>().enabled = false;


			player.DropCrate();

			player.GetComponent<AudioSource>().PlayOneShot(FindObjectOfType<BuildingBehavior>().buildingCollide, 0.5f);
			player.GetComponent<Animator>().Play("Damaged");

			if(player.crateCount > 0){
				FindObjectOfType<UIManager>().AddScore(-2 * player.crateCount);
			} else {
				FindObjectOfType<UIManager>().AddScore(-2);
			}

			player.crateCount = 0;
		}
	}
}
