﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public float hours;
	public float minutes;
	public float seconds;

	public GameObject phaseIndicator;
	public Text scoreText;
	public Text timeText;

	PlayerController player;


	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController>();
	
	}

	void Update(){
		hours = (int)(Time.time / 3600f);
		minutes = (int)(Time.time / 60f);
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
		scoreText.gameObject.GetComponent<Animator>().Play("AddScore");
		scoreText.text = "Score: " + player.score;
	}
}
