using UnityEngine;
using System.Collections;

public class Visualizer : MonoBehaviour {

	GameObject[] elements;

	// Use this for initialization
	void Start () {
		elements = GameObject.FindGameObjectsWithTag("VisualizerElement");
	}

	void Update(){
		float[] spectrum = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
		for (int i = 0; i < elements.Length; i++){
			Vector3 previousScale = elements[i].transform.localScale;
			previousScale.y = Mathf.Lerp(previousScale.y, spectrum[i] * 30, Time.deltaTime * 20);
			elements[i].transform.localScale = previousScale;
		}
	}
	

}
