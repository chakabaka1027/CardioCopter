using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {

	public GameObject particles;
	public AudioClip ringCollect;


	void FixedUpdate(){
		gameObject.transform.Translate(Vector3.left * 0.05f);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player"){

			FindObjectOfType<PlayerController>().DropCrate();

			Destroy(Instantiate(particles, gameObject.transform.position + Vector3.left * 1f, Quaternion.Euler(0, 90, 0)) as GameObject, 3);
			FindObjectOfType<UIManager>().AddScore(2);
			FindObjectOfType<PlayerController>().gameObject.GetComponent<AudioSource>().PlayOneShot(ringCollect, 1);
			Destroy(gameObject);
		}


	}
}
