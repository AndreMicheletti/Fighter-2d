using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : CharacterInput {

	void FixedUpdate() {
		
		fireTimer.Update ();

		int horizontal = (int) Input.GetAxisRaw("Horizontal");
		if (horizontal != 0) {
			character.startSmoothMovement((horizontal > 0 ? character.stats.Speed : -character.stats.Speed), 0);
		}
		if (character.isMoving ()) {
			UpdateFiring ();
		}
	}
} 
