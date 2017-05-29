using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

	public Transform spawnPoint;
	public GameObject[] prototypes;
	public Range enemySpawnDelayInFrames;
	public Range maxEnemiesInterval;
	public Range timeToNextWaveInSeconds;

	private int enemiesMaximum = 1;
	private int enemiesCount = 0;
	private int nextEnemyTimer = 0;
	private GameObject lastSpawnedEnemy;

	// Use this for initialization
	void Start () {
		enemiesMaximum = maxEnemiesInterval.getInt ();
		enemiesCount = 0;
		setTimer ();
	}

	void FixedUpdate() {
		if (enemiesCount >= enemiesMaximum) {
			if (lastSpawnedEnemy == null || lastSpawnedEnemy.activeSelf == false) {
				GameManager.instance.notifyWaveEnded (timeToNextWaveInSeconds);
				gameObject.SetActive (false);
				return;
			}
			return;
		}

		if (nextEnemyTimer > 0)
			nextEnemyTimer -= 1;
		else {
			setTimer ();
			SpawnEnemy ();
		}
	}

	void setTimer() {
		nextEnemyTimer = enemySpawnDelayInFrames.getInt ();
	}

	void SpawnEnemy() {
		GameObject selected = prototypes [Random.Range (0, prototypes.Length)];
		lastSpawnedEnemy = GameObject.Instantiate (selected, spawnPoint.position, Quaternion.identity, spawnPoint);
		enemiesCount += 1;
	}
}
