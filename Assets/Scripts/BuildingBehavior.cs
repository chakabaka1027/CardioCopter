using UnityEngine;
using System.Collections;

public class BuildingBehavior : MonoBehaviour {

	void FixedUpdate(){
		gameObject.transform.Translate(Vector3.left * 0.05f);
	}
}
