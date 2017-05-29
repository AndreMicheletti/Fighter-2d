using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 1f;
	public MovementType moveType = MovementType.CONSTANT;
	public KeyCode leftKey = KeyCode.A;
	public KeyCode rightKey = KeyCode.D;
	public Animator animator;

	public GameObject shot;
	public Transform shotParent;
	public Transform[] shotLocations;
	public int fireRateInFrames = 2;
	private float movementTargetX = 0f;
	private bool moving = false;

	private Rigidbody2D body;
	private PlayerInput input;

	private int shotTimer = 0;
	private int shotLocationIndex = 0;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update() {
		input = readInput ();
		handleInput ();
	}

	void FixedUpdate () {
		if (shotTimer > 0)
			shotTimer -= 1;
	}

	void handleInput() {
		switch (input) {
		case PlayerInput.MOVE_LEFT:
			Move (Direction.LEFT);
			break;
		case PlayerInput.MOVE_RIGHT:
			Move (Direction.RIGHT);
			break;
		}
		if (isMoving ()) {
			Shoot ();
		}
	}

	bool isMoving() {
		if (moving)
			return true;
		if (input != PlayerInput.NONE)
			return true;
		return false;
	}

	void Shoot() {
		if (shotTimer == 0) {
			Transform transform = shotLocations [shotLocationIndex];
			GameObject.Instantiate (shot, transform.position, transform.rotation, shotParent);

			shotLocationIndex = (shotLocationIndex >= shotLocations.Length - 1 ? 0 : shotLocationIndex + 1);
			shotTimer = fireRateInFrames;
		}
	}

	void Move(Direction dir) {
		
		float x_vel = (dir == Direction.RIGHT ? 1 : -1) * speed;

		if (moveType == MovementType.CONSTANT) {
			
			Vector3 newPos = new Vector3 (transform.position.x + x_vel, transform.position.y, transform.position.z);
			body.MovePosition (newPos);

		} else {
			if (moving == false) {
				movementTargetX = transform.position.x + x_vel;
				StartCoroutine (smoothMovement ());
			}
		}
	}

	IEnumerator smoothMovement() {
		float RemainingDistance = Mathf.Abs (transform.position.x - movementTargetX);
		moving = true;
		animator.SetTrigger ("Roll");
		while (RemainingDistance > 0.1f) {
			float x = Mathf.MoveTowards (transform.position.x, movementTargetX, Time.deltaTime * 2f);
			body.MovePosition (new Vector3 (x, body.position.y, 0));
			RemainingDistance = Mathf.Abs (transform.position.x - movementTargetX);
			yield return new WaitForFixedUpdate ();
		}
		moving = false;
	}

	PlayerInput readInput() {
		if (Input.GetKey (leftKey))
			return PlayerInput.MOVE_LEFT;
		if (Input.GetKey (rightKey))
			return PlayerInput.MOVE_RIGHT;
		return PlayerInput.NONE;
	}

	private enum PlayerInput {
		MOVE_LEFT,
		MOVE_RIGHT,
		NONE
	}
}

public enum Direction {
	LEFT,
	RIGHT,
	UP,
	DOWN
}

public enum MovementType {
	CONSTANT,
	MANEUVER
}