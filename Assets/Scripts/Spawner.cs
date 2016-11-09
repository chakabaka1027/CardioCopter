using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

	public bool devMode = false;

	public GameObject jewel;
	public GameObject building;
	public GameObject ring;

	public UIManager uiManager;

	public enum ExerciseStage{warmUp, workOut, coolDown, finished};
	public ExerciseStage exerciseStage;

	float nextSpawnTime;



	void Start(){
		uiManager = FindObjectOfType<UIManager>();

		if(devMode == true){
			StartCoroutine(WarmUpPhase());
		} else if (devMode == false){
			StartCoroutine(PlayPhases());
		}
	}

	void Update(){
		if(devMode == true){
			if(Input.GetKeyDown(KeyCode.RightArrow) && exerciseStage == ExerciseStage.warmUp){
				StopCoroutine(WarmUpPhase());
				StartCoroutine(WorkOutPhase());
			} 

			else if(Input.GetKeyDown(KeyCode.RightArrow) && exerciseStage == ExerciseStage.workOut){
				StopCoroutine(WorkOutPhase());

				StartCoroutine(CoolDownPhase());
			} else if(Input.GetKeyDown(KeyCode.RightArrow) && exerciseStage == ExerciseStage.coolDown){
				StopCoroutine(CoolDownPhase());

				StartCoroutine(Finished());
			} 

			if(Input.GetKeyDown(KeyCode.LeftArrow) && exerciseStage == ExerciseStage.workOut){
				StopCoroutine(WorkOutPhase());
				StartCoroutine(WarmUpPhase());
			} 

			else if(Input.GetKeyDown(KeyCode.LeftArrow) && exerciseStage == ExerciseStage.coolDown){
				StopCoroutine(CoolDownPhase());

				StartCoroutine(WorkOutPhase());
			} else if(Input.GetKeyDown(KeyCode.LeftArrow) && exerciseStage == ExerciseStage.finished){
				StopCoroutine(Finished());

				StartCoroutine(CoolDownPhase());
			}
		}
	}

	IEnumerator PlayPhases(){
		StartCoroutine(WarmUpPhase());
		yield return new WaitForSeconds(60);
		StopCoroutine(WarmUpPhase());
		StartCoroutine(WorkOutPhase());
		yield return new WaitForSeconds(180);
		StopCoroutine(WorkOutPhase());
		StartCoroutine(CoolDownPhase());
		yield return new WaitForSeconds(60);
		StopCoroutine(CoolDownPhase());
		StartCoroutine(Finished());
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

		yield return new WaitForSeconds(4f);

		StartCoroutine(uiManager.PhaseIndicatorAnimation("Work Out Phase"));


		while(exerciseStage == ExerciseStage.workOut){
			GameObject currentBuilding = Instantiate(building, new Vector2(14, Random.Range(-8f, -4f)), Quaternion.identity) as GameObject;
			SpawnJewel(currentBuilding.transform.position);
			Destroy(currentBuilding, 15f);

			yield return new WaitForSeconds(4f);
		}
	}

	public void SpawnJewel(Vector2 offset){
		Destroy(Instantiate(jewel, offset + Vector2.up * Random.Range(9f, 11f), Quaternion.identity), 15);
	}

	public IEnumerator CoolDownPhase(){
		exerciseStage = ExerciseStage.coolDown;

		yield return new WaitForSeconds(4f);

		StartCoroutine(uiManager.PhaseIndicatorAnimation("Cool Down Phase"));

		while(exerciseStage == ExerciseStage.coolDown){
			Destroy(Instantiate(ring, new Vector2(14, Random.Range(-3f, 3f)), Quaternion.identity), 15);

			yield return new WaitForSeconds(4f);
		}
	}

	public IEnumerator Finished(){

		exerciseStage = ExerciseStage.finished;

		yield return new WaitForSeconds(9f);

		StartCoroutine(uiManager.PhaseIndicatorAnimation("Great Flying!"));
		FindObjectOfType<PlayerController>().audioSource.PlayOneShot(uiManager.cheerSound, 0.4f);

		yield return new WaitForSeconds(2f);

		FindObjectOfType<UIManager>().blackFade.GetComponent<Animator>().Play("FadeOut");


		yield return new WaitForSeconds(2f);

		FindObjectOfType<UIManager>().postScoreText.gameObject.SetActive(true);
		FindObjectOfType<UIManager>().PostGameScore();
		FindObjectOfType<UIManager>().postScoreText.GetComponent<Animator>().Play("FadeIn");


	}

}
