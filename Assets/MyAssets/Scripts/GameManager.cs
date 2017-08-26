using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[Header("Stats")]
	[SerializeField] float maxTolerance = 100;
	public int damageMultiplier = 5;

	[Header("Tolerance Bar")]
	public Transform pointer;
	public Transform barStart;
	public Transform barEnd;

	[Header("Timer")]
	public float waitTime = 1f;

	float currentTolerance;
	int currentHands = 0;
	float elapsedTime = 0f;

	// Use this for initialization
	void Awake() {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	void Start(){
		currentTolerance = maxTolerance;
	}
	
	// Update is called once per frame
	void Update () {
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
	}
}
