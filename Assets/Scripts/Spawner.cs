using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

	public GameObject jewel;
	public GameObject building;
	public GameObject ring;

	public GameObject phaseIndicator;

	public enum ExerciseStage{warmUp, exercise, coolDown};
	public ExerciseStage exerciseStage;

	float nextSpawnTime;



	void Start(){
//		StartCoroutine(SpawnBuilding());
		exerciseStage = ExerciseStage.warmUp;

		StartCoroutine(SpawnRings());
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			exerciseStage = ExerciseStage.exercise;
			StartCoroutine(SpawnBuilding());
		}
	}

	public IEnumerator SpawnRings(){

		phaseIndicator.GetComponent<Text>().text = "Warm Up Phase!";

		yield return new WaitForSeconds(1);
		phaseIndicator.GetComponent<Animator>().Play("FadeOut");

		while(exerciseStage == ExerciseStage.warmUp){
			Destroy(Instantiate(ring, new Vector2(14, Random.Range(-3f, 3f)), Quaternion.identity), 15);

			yield return new WaitForSeconds(4f);
		}
	}

	public IEnumerator SpawnBuilding(){

		phaseIndicator.GetComponent<Animator>().Play("Spin");
		phaseIndicator.GetComponent<Text>().text = "Work Out Phase!";
		yield return new WaitForSeconds(1);
		phaseIndicator.GetComponent<Animator>().Play("FadeOut");

		while(exerciseStage == ExerciseStage.exercise){
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
