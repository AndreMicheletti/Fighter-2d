using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
	
	public CharacterStats stats;
	
	public Character character;

	public float smoothMovementValue = 2f;

	private new Rigidbody2D body;
	private float movementTargetX = float.NaN;
	private float movementTargetY = float.NaN;
	public bool moving = false;

	private Timer energyTimer = new Timer();
	
	void Start() {
		character = new Character(stats);
		body = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate() {
		if (isDead()) {
			updateDie ();
			return;
		}
		updateEnergy ();
	}

	void updateDie() {
		character.currEnergy = 0;
		Destroy (gameObject);
	}

	void updateEnergy() {
		energyTimer.Update ();

		if (energyTimer.Finished ()) {
			if (isMoving ())
				character.RechargeEnergy ();
			else
				character.DepleteEnergy ();
			energyTimer.Reset (stats.EnergyRateInFrames);
		}
	}
	
	bool isDead() {
		return character.isDead();
	}
	
	public void MovePosition(float _x, float _y) {
		Vector3 newPos = transform.position;
		newPos.x += _x; newPos.y += _y;
		transform.position = newPos;
		// body.MovePosition(newPos);
	}
	
	public void Move(float _xVel, float _yVel) {
		body.velocity = new Vector2(_xVel, _yVel);
	}
	
	public void startSmoothMovement(float _x, float _y) {
		if (isDead ())
			return;
		if (moving == true) 
			return;
		movementTargetX = transform.position.x + _x;
		movementTargetY = transform.position.y + _y;
		StartCoroutine(smoothMovement());		
	}
	
	IEnumerator smoothMovement() {
		moving = true;
		float RemainingDistance = Mathf.Abs (transform.position.x - movementTargetX) + Mathf.Abs (transform.position.y - movementTargetY);
		while (RemainingDistance > 0.1f) {
			float x = Mathf.MoveTowards (transform.position.x, movementTargetX, Time.deltaTime * smoothMovementValue);
			float y = Mathf.MoveTowards (transform.position.y, movementTargetY, Time.deltaTime * smoothMovementValue);
			body.MovePosition (new Vector3 (x, y, 0));
			RemainingDistance = Mathf.Abs (transform.position.x - movementTargetX) + Mathf.Abs (transform.position.y - movementTargetY);
			yield return new WaitForFixedUpdate ();
		}
		moving = false;
		movementTargetX = float.NaN;
		movementTargetY = float.NaN;
	}
	
	public bool isMoving() {
		return moving;
	}

	// Fighter2D specific

	public Transform[] turrets;
	private int turretIndex = 0;

	public Transform getTurret() {
		if (turrets.Length == 1) {
			return turrets [0];
		} else {
			Transform selected = turrets [turretIndex];
			turretIndex++;
			if (turretIndex >= turrets.Length)
				turretIndex = 0;
			return selected;
		}
	}
	
}
