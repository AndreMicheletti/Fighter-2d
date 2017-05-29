using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour {

	public float maxSpeed = 1f;
	private Rigidbody2D body;

	// Use this for initialization
	void Awake () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		MoveByVelocity ();
	}

	void MoveByVelocity() {
		body.velocity = new Vector2(0f, maxSpeed);
	}

	void MoveByAngle() {
		float angle = transform.eulerAngles.magnitude * Mathf.Deg2Rad;

		float x = (Mathf.Sin (angle) * -maxSpeed) * Time.deltaTime;
		float y = (Mathf.Cos (angle) * maxSpeed) * Time.deltaTime;

		body.velocity = new Vector2(x * maxSpeed, y * maxSpeed);
	}
}
