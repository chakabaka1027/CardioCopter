using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject jewel;
	public GameObject building;
	float nextSpawnTime;

	void Start(){
		StartCoroutine(SpawnBuilding());

	}

	public IEnumerator SpawnBuilding(){

		while(true){
			GameObject currentBuilding = Instantiate(building, new Vector2(14, Random.Range(-3f, 1f)), Quaternion.identity) as GameObject;
			SpawnJewel(currentBuilding.transform.position);
			Destroy(currentBuilding, 15f);

			yield return new WaitForSeconds(4f);
		}
	}

	public void SpawnJewel(Vector2 offset){
		Destroy(Instantiate(jewel, offset + Vector2.up * Random.Range(5f, 7f), Quaternion.identity), 15);
	}
}
