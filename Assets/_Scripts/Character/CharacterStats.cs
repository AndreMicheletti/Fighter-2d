using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStats : ScriptableObject {
	public int MaximumHealth = 1;
	public int MaximumEnergy = 0;
	public int EnergyRateInFrames = 5;
	public int CostForOneHealth = 5;
	public float Speed = 1;
	public int FireRateInFrames = 10;
	public GameObject projectile;
}
