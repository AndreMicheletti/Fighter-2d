using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

	public CharacterController player;


	public Text healthText;
	public Text energyText;

	// Update is called once per frame
	void FixedUpdate () {
		updateTexts ();
	}

	void updateTexts() {
		healthText.text = ""+player.character.currHealth;
		energyText.text = ""+player.character.currEnergy;
	}
}
