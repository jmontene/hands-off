using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour {

	public GameManager manager;
	public Image fader;
	public float timeToStart = 2f;

	Color origColor;
	Color targetColor;

	// Use this for initialization
	void Start () {
		origColor = new Color (fader.color.r, fader.color.g, fader.color.b, fader.color.a);
		targetColor = new Color (fader.color.r, fader.color.g, fader.color.b, 0f);

		StartCoroutine (StartGame ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator StartGame(){
		float timeElapsed = 0f;
		while (timeElapsed < timeToStart) {
			timeElapsed += Time.deltaTime;
			fader.color = Color.Lerp (origColor, targetColor, timeElapsed / timeToStart);
			yield return null;
		}

		manager.enabled = true;
	}
}
