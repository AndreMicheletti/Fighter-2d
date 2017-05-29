using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer {

	private int curr = 0;

	public void Update () {
		if (curr > 0)
			curr -= 1;
	}

	public void Reset(int _max) {
		curr = _max;
	}

	public void Stop() {
		curr = 0;
	}

	public bool Finished() {
		return curr == 0;
	}
}
