using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : CharacterInput {

	public Range horizontalMovementRange;
	public Range horizontalMovementDelay;
	public float maxDistance = 1.8f;

	private Timer hMoveTimer = new Timer();

	void FixedUpdate() {
		fireTimer.Update ();
		UpdateFiring ();


		hMoveTimer.Update ();
		if (hMoveTimer.Finished()) {
			MoveHorizontal();
			hMoveTimer.Reset (horizontalMovementDelay.getInt ());
		}

		//character.MovePosition (0, -character.stats.Speed);
	}

	void MoveHorizontal() {
		float targetX = horizontalMovementRange.getFloat ();
		float distance = Mathf.Abs (transform.position.x - targetX);
		if (distance > maxDistance) {
			targetX -= (maxDistance - distance);
		}
		character.startSmoothMovement (targetX, -character.stats.Speed);
	}
}
