using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour {

	protected Command currentCommand;

	public abstract void update();

	protected void setCommand (Command _command) {
		this.currentCommand = _command;
	}

	public Command getCommand () {
		return this.currentCommand;
	}
}

public enum Command {
	MOVE_LEFT,
	MOVE_RIGHT,
	ATTACK,
	NONE
}

public enum BehaviourList {
	ZigZag,
	NONE
}