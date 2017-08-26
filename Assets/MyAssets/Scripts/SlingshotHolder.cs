using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotHolder : MonoBehaviour {
	
	[SerializeField] float maxStretch = 3.0f;
	[SerializeField] LineRenderer base_left;
	[SerializeField] LineRenderer base_right;
	[SerializeField] Transform slingshotBase;
	[SerializeField] GameObject projectilePrefab;
	[SerializeField] float waitTime = 0.1f;
	[SerializeField] float mouseThreshold = 1f;

	SpringJoint2D leftSpring;
	SpringJoint2D rightSpring;
	bool clickedOn = false;
	Rigidbody2D rb;
	Ray rayToMouse;
	float maxStretchSqr;
	Vector3 prevMousePos;

	void Awake(){
		SpringJoint2D[] springs = GetComponents<SpringJoint2D> ();
		rightSpring = springs [0];
		leftSpring = springs [1];
		rb = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		LineRendererSetup ();
		rayToMouse = new Ray (slingshotBase.position, Vector3.zero);
		maxStretchSqr = maxStretch * maxStretch;
	}
	
	// Update is called once per frame
	void Update () {
		if (clickedOn) {
			Dragging ();
		}

		if (transform.position.y >= base_left.transform.position.y) {
			transform.position = new Vector3(transform.position.x, base_left.transform.position.y, transform.position.z);
			rb.velocity = Vector2.zero;
		}

		base_left.SetPosition (1, transform.position);
		base_right.SetPosition (1, transform.position);
	}

	void LineRendererSetup(){
		base_left.SetPosition (0, base_left.transform.position);
		base_right.SetPosition (0, base_right.transform.position);

		base_left.sortingLayerName = "Foreground";
		base_right.sortingLayerName = "Foreground";

		base_left.sortingOrder = 1;
		base_right.sortingOrder = 1;
	}

	void OnMouseDown(){
		leftSpring.enabled = false;
		rightSpring.enabled = false;
		clickedOn = true;

		prevMousePos = Input.mousePosition;
	}

	void OnMouseUp(){
		leftSpring.enabled = true;
		rightSpring.enabled = true;
		rb.isKinematic = false;
		clickedOn = false;

		StartCoroutine (Shoot ());
	}

	IEnumerator Shoot(){
		Vector3 curMousePos = Input.mousePosition;
		yield return new WaitForSeconds (waitTime);
		if (Vector3.Distance (prevMousePos, curMousePos) >= mouseThreshold) {
			Projectile p = Instantiate (projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile> ();
			p.direction = rb.velocity.normalized;
			p.GetComponent<SpriteRenderer> ().color = Random.ColorHSV (0f, 1f, 0f, 0.5f, 0f, 1f);
		}
	}

	void Dragging(){
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 catapultToMouse = mouseWorldPoint - slingshotBase.position;

		if (catapultToMouse.sqrMagnitude > maxStretchSqr) {
			rayToMouse.direction = catapultToMouse;
			mouseWorldPoint = rayToMouse.GetPoint (maxStretch);
		}

		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}
}
