using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {

	void FixedUpdate(){
		gameObject.transform.Translate(Vector3.left * 0.05f);
	}
}
