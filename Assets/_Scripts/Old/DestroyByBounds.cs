using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBounds : MonoBehaviour {
	
	public static int boundLayerId = 8;

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.layer == boundLayerId) {
			Destroy (gameObject);
		}
	}
}
