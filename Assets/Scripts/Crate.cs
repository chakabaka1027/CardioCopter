using UnityEngine;
using System.Collections;

public class Crate : MonoBehaviour {

	public int crateCount = 0;

	PlayerController player;


	float min=2f;
    float max=3f;

	void Start(){
		player = FindObjectOfType<PlayerController>();
		
		min=transform.position.x - 0.1f;
        max=transform.position.x + 0f;
	}

	void FixedUpdate(){

		if (player.hasCrate == true){
			transform.position =new Vector3(Mathf.PingPong(Time.time * 0.17f, max-min) + min, transform.position.y, transform.position.z);
		}
	}

}
