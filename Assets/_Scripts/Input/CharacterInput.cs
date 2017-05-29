using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterInput : MonoBehaviour {
	
	protected Timer fireTimer = new Timer ();

	public CharacterController character;

	protected void UpdateFiring() {
		if (fireTimer.Finished ()) {
			fireTimer.Reset (character.stats.FireRateInFrames);
			Fire ();
		}
	}

	protected void Fire() {
		Debug.Log ("FIRING");
		Transform turret = character.getTurret ();
		GameObject.Instantiate (character.stats.projectile, turret.position, character.stats.projectile.transform.rotation, GameManager.instance.propsParent);
	}
}
