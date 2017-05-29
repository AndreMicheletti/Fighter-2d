using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {
	
	public CharacterStats stats;
	
	public int currHealth;
	public int currEnergy;
	private bool dead = false;
	private int energyUsed = 0;
	
	public Character(CharacterStats _stats) {
		this.stats = _stats;
		currHealth = stats.MaximumHealth;
		currEnergy = 0;
		dead = false;
	}
	
	public void Damage(int _value) {
		addHealth (-_value);
		if (currHealth <= 0) {
			currHealth = 0;
			dead = true;
		}
	}

	public void RechargeEnergy() {
		if (addEnergy (1))
			energyUsed = 0;
	}

	public void DepleteEnergy() {
		if (addEnergy (-1))
			energyUsed += 1;
		if (energyUsed >= stats.CostForOneHealth) {
			addHealth (1);
			energyUsed = 0;
		}
	}

	bool addEnergy(int _value) {
		if (canAdd (currEnergy + _value, stats.MaximumEnergy, 0)) {
			currEnergy += _value;
			return true;
		}
		return false;
	}

	bool addHealth(int _value) {
		if (canAdd (currHealth + _value, stats.MaximumHealth, 0)) {
			currHealth += _value;
			return true;
		}
		return false;
	}

	bool canAdd(int _value, int _max, int _min) {
		if (_value > _max || _value < _min)
			return false;
		return true;
	}
	
	public bool isDead() { return dead; }
	
}
