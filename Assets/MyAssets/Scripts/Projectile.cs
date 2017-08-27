using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] float aliveTime = 2f;
	[HideInInspector] public Vector2 direction;

	void Start(){
		Destroy(this.gameObject, aliveTime);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (direction * speed * Time.deltaTime);
	}
}
