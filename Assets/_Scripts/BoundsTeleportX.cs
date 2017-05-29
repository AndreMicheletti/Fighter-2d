using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsTeleportX : MonoBehaviour {

	public CharacterController parent;
	public string targetBoundary;

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == targetBoundary) {
			Vector2 newPos = parent.transform.position;
			newPos.x *= -1f;
			newPos.x += (newPos.x > 0 ? -0.2f : 0.2f);
			parent.transform.position = newPos;
			parent.StopAllCoroutines (); parent.moving = false;
		}
	}
}
