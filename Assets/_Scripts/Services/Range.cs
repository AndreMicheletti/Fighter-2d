using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Range {
	public float min = 0;
	public float max = 1;

	public Range(float _min, float _max) {
		this.min = _min;
		this.max = _max;
	}

	public float getFloat() {
		return Random.Range (min, max);
	}

	public int getInt() {
		return (int)Random.Range ((int)min, (int)max);
	}
}
