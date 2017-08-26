using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poofScripts : MonoBehaviour {
	public float waitTime = 0.3f;

	void Start(){
		Destroy (this.gameObject,waitTime);
	}

}
