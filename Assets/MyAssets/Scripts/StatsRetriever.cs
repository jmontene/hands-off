using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsRetriever : MonoBehaviour {

	public Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText.text = GameManager.instance.GetScore ().ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
