using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public int atkValue = 1;
	public string ignore = "";

	void OnTriggerEnter2D(Collider2D _other) {
		try {
			if (_other.tag == ignore)
				return;
			CharacterController _char = _other.GetComponent<CharacterController> ();
			if (_char != null) {
				_char.character.Damage (atkValue);
				Destroy (gameObject);
			}
		} catch (UnityException e) {
			Destroy (gameObject);
		}
	}
}
