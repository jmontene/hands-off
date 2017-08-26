using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poofScripts : MonoBehaviour {
	public float waitTime = 0.3f;

	AudioSource source;

	void Awake(){
		source = GetComponent<AudioSource> ();
	}

	void Start(){
		source.Play ();
		Destroy (this.gameObject,waitTime);
	}

}
