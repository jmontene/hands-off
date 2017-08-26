using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHand : MonoBehaviour {

	//[SerializeField] Vector2 dest;
	//[SerializeField] float interval;
	[SerializeField] GameObject hand;

	bool canSpawn = true;

	public float MinX = -6.05f;
	public float MaxX = 7.25f;
	public float MinY = -1.75f;
	public float MaxY = 1.95f;

	void Star(){
		SpawnObj ();
	}

	void SpawnObj(){
		float x = Random.Range(MinX,MaxX);
		float y = Random.Range(MinY,MaxY);
		if (canSpawn) {
			Instantiate(hand.gameObject, new Vector3(x,y,0), transform.rotation);
		}
	}


}
