using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handScripts : MonoBehaviour {

	public float speed = 2;
	public Transform hand;
	public Transform endPos;
	public Transform startPos;
	Transform currentPos;

	void OnTriggerEnter2D(Collider2D other){
	
		if (other.tag == "projectile") {
			GameManager.instance.RemoveHand ();
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		currentPos = endPos;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (currentPos == endPos) {
			if (hand.position.y > endPos.position.y) {
				hand.transform.Translate (Vector3.down * speed * Time.deltaTime);
			} else {
				currentPos = startPos;
			}
		} else {
			if (hand.position.y < startPos.position.y) {
				hand.transform.Translate (Vector3.up * speed * Time.deltaTime);
			} else {
				currentPos = endPos;
			}
		}
			
	}
}
