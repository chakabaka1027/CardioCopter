using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public AudioClip cheerSound;
		
	public float hours;
	public float minutes;
	public float seconds;

	public GameObject blackFade;

	public ParticleSystem[] backgroundFireworks;


	public GameObject phaseIndicator;
	public Text scoreText;
	public Text timeText;

	public Text postScoreText;


	PlayerController player;


	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController>();
		blackFade.GetComponent<Animator>().Play("FadeIn");	
	}

	void Update(){
		hours = (int)((Time.time / 3600f) % 60);
		minutes = (int)((Time.time / 60f) % 60);
		seconds = (int)(Time.time % 60f);
		timeText.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
	}



	public IEnumerator PhaseIndicatorAnimation(string phaseName){
		phaseIndicator.GetComponent<Animator>().Play("Spin");
		phaseIndicator.GetComponent<Text>().text = phaseName;

		yield return new WaitForSeconds(1);

		phaseIndicator.GetComponent<Animator>().Play("FadeOut");
	}

	public void AddScore(int addedScore){
		player.score += addedScore;
		if (player.score < 0){
			player.score = 0;
		}

		scoreText.gameObject.GetComponent<Animator>().Play("AddScore");
		scoreText.text = "Score: " + player.score;
	}

	public IEnumerator Celebration(){
		player.GetComponent<AudioSource>().PlayOneShot(cheerSound, 0.3f);
		foreach(ParticleSystem firework in backgroundFireworks){
			firework.gameObject.SetActive(true);
			firework.loop = true;

			firework.Play();

			yield return new WaitForSeconds(1.5f);

			firework.loop = false;
		}
	}

	public void PostGameScore(){
		postScoreText.text = "Score: " + player.score;

	}	
}
