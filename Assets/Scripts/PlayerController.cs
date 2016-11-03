using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public bool isDamaged = false;
	public GameObject crate;
	public bool hasCrate = false;

	Rigidbody2D rb;
	float thrust = 5;
	Animator animator;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
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
		GameObject currentCrate = Instantiate(crate, gameObject.transform.position + Vector3.down, Quaternion.identity) as GameObject;
		currentCrate.transform.parent = gameObject.transform;
	}

	void DropCrate(){
		if (hasCrate == true){
			GameObject crate = gameObject.transform.GetChild(0).gameObject;
			gameObject.transform.DetachChildren();
			crate.GetComponent<Rigidbody2D>().isKinematic = false;
			hasCrate = false;
		}
	}
}
