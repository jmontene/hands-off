using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour {

	[SerializeField] string levelToLoad;
	[SerializeField] Image fader;
	[SerializeField] float timeToFade = 2f;

	Color origColor;
	Color targetColor;

	void Start(){
		origColor = new Color (fader.color.r, fader.color.g, fader.color.b, fader.color.a);
		targetColor = new Color (fader.color.r, fader.color.g, fader.color.b, 1f);
	}

	public void DoSceneChange(){
		StartCoroutine (FadeOut ());
	}

	IEnumerator FadeOut(){
		float timeElapsed = 0f;
		while (timeElapsed < timeToFade) {
			timeElapsed += Time.deltaTime;
			fader.color = Color.Lerp (origColor, targetColor, timeElapsed / timeToFade);
			yield return null;
		}
		SceneManager.LoadScene (levelToLoad);
	}

}
