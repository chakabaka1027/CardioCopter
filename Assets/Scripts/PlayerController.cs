using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[Header("Sounds")]
	public AudioClip startSound;
	public AudioClip crateDrop;
	public AudioClip damage;

	public GameObject crateText;
	public GameObject crate;
	public bool hasCrate = false;
	public GameObject currentCrateCounter;

	public int score = 0;

	Rigidbody2D rb;
	float thrust = 5;
	public AudioSource audioSource;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.LeftShift)){
			rb.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
		}

		if(Input.GetKeyDown(KeyCode.Space) && hasCrate == true){

			audioSource.PlayOneShot(crateDrop, 0.75f);
			DropCrate();
		}
	}

	public void HasCrate(){
		hasCrate = true;
		GameObject currentCrate = Instantiate(crate, gameObject.transform.position + Vector3.down * 0.75f, Quaternion.identity) as GameObject;
		currentCrate.transform.parent = gameObject.transform;
		currentCrateCounter = Instantiate(crateText, currentCrate.transform.position + Vector3.back, Quaternion.identity) as GameObject;
		currentCrateCounter.transform.parent = currentCrate.gameObject.transform;

		FindObjectOfType<PlayerController>().gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, -.11f);
		FindObjectOfType<PlayerController>().gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.55f, .45f);

	}

	public void DropCrate(){
		if (hasCrate == true){
			FindObjectOfType<PlayerController>().gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
			FindObjectOfType<PlayerController>().gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.55f, 0.19f);

			GameObject crate = gameObject.transform.GetChild(0).gameObject;
			crate.GetComponent<BoxCollider2D>().enabled = true;
			gameObject.transform.DetachChildren();
			crate.GetComponent<Rigidbody2D>().isKinematic = false;
			hasCrate = false;
			GetComponent<Rigidbody2D>().mass = 2;
			Destroy(crate, 4);

		}
	}
}
