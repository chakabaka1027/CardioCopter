using UnityEngine;
using System.Collections;

public class BuildingSpawner : MonoBehaviour {

	public GameObject building;
	float nextSpawnTime;

	void Start(){
		StartCoroutine(SlowSpawner());
	}

	public IEnumerator SlowSpawner(){
		yield return new WaitForSeconds(1.5f);

		while(true){

			yield return new WaitForSeconds(5f);

			Instantiate(building, new Vector2(14, Random.Range(-3, 1)), Quaternion.identity);

		}
	}
}
