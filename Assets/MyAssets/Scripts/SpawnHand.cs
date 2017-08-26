using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHand : MonoBehaviour {

	//[SerializeField] Vector2 dest;
	//[SerializeField] float interval;
	[SerializeField] GameObject[] hand;
	public Transform upperLeft;
	public Transform lowerRight;


	bool canSpawn = true;


	void Update(){
		SpawnObj ();
	}

	void SpawnObj(){
		int index = Random.Range (0, hand.Length - 1);

		float x = Random.Range(upperLeft.position.x,lowerRight.position.x);
		float y = Random.Range(upperLeft.position.y,lowerRight.position.y);
		if (canSpawn) {
			Instantiate(hand[index], new Vector3(x,y,0), transform.rotation);
		}
	}


}
