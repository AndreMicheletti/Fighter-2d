using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagBehaviour : EnemyBehaviour {

	public static Range timeInFrames = new Range(200, 300);

	private int timer = 0;

	public ZigZagBehaviour() {
		timer = 0;
	} 


	public override void update() {
		if (timer <= 0) {
			timer = ZigZagBehaviour.timeInFrames.getInt();
			setCommand ((getCommand () == Command.MOVE_LEFT) ? Command.MOVE_RIGHT : Command.MOVE_LEFT);
		} else
			timer -= 1;
	}

}
