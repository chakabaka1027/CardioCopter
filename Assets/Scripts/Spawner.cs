using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

	public GameObject jewel;
	public GameObject building;
	public GameObject ring;

	public UIManager uiManager;

	public enum ExerciseStage{warmUp, workOut, coolDown};
	public ExerciseStage exerciseStage;

	float nextSpawnTime;



	void Start(){
		uiManager = FindObjectOfType<UIManager>();
		StartCoroutine(WarmUpPhase());
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.RightArrow) && exerciseStage == ExerciseStage.warmUp){
			StopCoroutine(WarmUpPhase());
			StartCoroutine(WorkOutPhase());
		} 

		else if(Input.GetKeyDown(KeyCode.RightArrow) && exerciseStage == ExerciseStage.workOut){
			StopCoroutine(WorkOutPhase());

			StartCoroutine(CoolDownPhase());
		}

		if(Input.GetKeyDown(KeyCode.LeftArrow) && exerciseStage == ExerciseStage.workOut){
			StopCoroutine(WorkOutPhase());
			StartCoroutine(WarmUpPhase());
		} 

		else if(Input.GetKeyDown(KeyCode.LeftArrow) && exerciseStage == ExerciseStage.coolDown){
			StopCoroutine(CoolDownPhase());

			StartCoroutine(WorkOutPhase());
		}
	}

	public IEnumerator WarmUpPhase(){
		yield return new WaitForSeconds(1);
		FindObjectOfType<PlayerController>().audioSource.PlayOneShot(FindObjectOfType<PlayerController>().startSound, 0.15f);

		exerciseStage = ExerciseStage.warmUp;
		StartCoroutine(uiManager.PhaseIndicatorAnimation("Warm Up Phase"));

		while(exerciseStage == ExerciseStage.warmUp){
			Destroy(Instantiate(ring, new Vector2(14, Random.Range(-3f, 3f)), Quaternion.identity), 15);

			yield return new WaitForSeconds(4f);
		}
	}

	public IEnumerator WorkOutPhase(){
		exerciseStage = ExerciseStage.workOut;
		StartCoroutine(uiManager.PhaseIndicatorAnimation("Work Out Phase"));


		while(exerciseStage == ExerciseStage.workOut){
			GameObject currentBuilding = Instantiate(building, new Vector2(14, Random.Range(-3f, 1f)), Quaternion.identity) as GameObject;
			SpawnJewel(currentBuilding.transform.position);
			Destroy(currentBuilding, 15f);

			yield return new WaitForSeconds(4f);
		}
	}

	public void SpawnJewel(Vector2 offset){
		Destroy(Instantiate(jewel, offset + Vector2.up * Random.Range(5f, 7f), Quaternion.identity), 15);
	}

	public IEnumerator CoolDownPhase(){
		exerciseStage = ExerciseStage.coolDown;
		StartCoroutine(uiManager.PhaseIndicatorAnimation("Cool Down Phase"));


		while(exerciseStage == ExerciseStage.coolDown){
			Destroy(Instantiate(ring, new Vector2(14, Random.Range(-3f, 3f)), Quaternion.identity), 15);

			yield return new WaitForSeconds(4f);
		}
	}

}
