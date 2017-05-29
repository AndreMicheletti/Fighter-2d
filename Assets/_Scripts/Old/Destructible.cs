using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	public Enemy enemy;
	public string DestroyedBy = "Projectile";

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == DestroyedBy) {
			if (enemy == null)
				Destroy (gameObject);
			else
				enemy.hit (1);
			Destroy (other.gameObject);
		}
	}
}
