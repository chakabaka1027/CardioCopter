using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[Header("Sounds")]
	public AudioClip startSound;

	public bool isDamaged = false;
	public GameObject crate;
	public bool hasCrate = false;

	public int score = 0;

	Rigidbody2D rb;
	float thrust = 5;
	Animator animator;
	public AudioSource audioSource;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.LeftShift)){
			rb.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
		}

		if (isDamaged == true){
			animator.Play("Damaged");
		} else if (isDamaged == false){
			animator.Play("Flying");
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			DropCrate();
		}
	}

	public void HasCrate(){
		hasCrate = true;
		GameObject currentCrate = Instantiate(crate, gameObject.transform.position + Vector3.down * 0.75f, Quaternion.identity) as GameObject;
		currentCrate.transform.parent = gameObject.transform;
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
