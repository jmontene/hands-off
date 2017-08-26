using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField] float speed;
	[HideInInspector] public Vector2 direction;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direction * speed * Time.deltaTime);
	}
}
