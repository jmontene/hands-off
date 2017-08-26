using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[Header("Stats")]
	[SerializeField] float maxTolerance = 100;
	public int damageMultiplier = 5;
	public float healAmount = 20;
	public string gameOverScene = "GameOver";

	[Header("Tolerance Bar")]
	public Transform pointer;
	public Transform barStart;
	public Transform barEnd;

	[Header("Timer")]
	public float waitTime = 1f;

	[Header("Spawns")]
	public SpawnHand spawner;
	public int maxSpawns = 10;

	[Header("UI")]
	public Text scoreText;

	float currentTolerance;
	int currentHands = 0;
	float elapsedTime = 0f;
	int score = 0;
	bool gameOver = false;

	// Use this for initialization
	void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	void Start(){
		currentTolerance = maxTolerance;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver) {
			return;
		}

		if (currentTolerance <= 0) {
			gameOver = true;
			SceneManager.LoadScene (gameOverScene);
		}

		spawner.enabled = currentHands < maxSpawns;

		elapsedTime += Time.deltaTime;

		if (elapsedTime >= waitTime) {
			elapsedTime = 0f;
			currentTolerance -= currentHands * damageMultiplier;
		}

		pointer.position = Vector3.Lerp (barEnd.position, barStart.position, currentTolerance / maxTolerance);
	}

	public void AddHand(){
		currentHands += 1;
	}

	public void RemoveHand(){
		currentHands -= 1;
		score += 1;
		currentTolerance += healAmount;
		if (currentTolerance > maxTolerance) {
			currentTolerance = maxTolerance;
		}
		scoreText.text = score.ToString ();
	}

	public int GetScore(){
		return score;
	}
}
