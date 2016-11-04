using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject phaseIndicator;
	public Text scoreText;

	PlayerController player;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
	
	}
	
	public IEnumerator PhaseIndicatorAnimation(string phaseName){
		phaseIndicator.GetComponent<Animator>().Play("Spin");
		phaseIndicator.GetComponent<Text>().text = phaseName;

		yield return new WaitForSeconds(1);

		phaseIndicator.GetComponent<Animator>().Play("FadeOut");
	}

	public void AddScore(int addedScore){
		player.score += addedScore;
		scoreText.gameObject.GetComponent<Animator>().Play("AddScore");
		scoreText.text = "Score: " + player.score;
	}
}
