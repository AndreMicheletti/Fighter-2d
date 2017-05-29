using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public Transform propsParent;

	public int[] wavesBuildIndex;
	public float FirstWaveDelayInSeconds = 2.0f;

	private AsyncOperation unloadingOperation;
	private int waveId;
	private float nextWaveTimer = 0;

	// Use this for initialization
	void Start () {
		if (GameManager.instance == null)
			GameManager.instance = this;
		else if (GameManager.instance != this) {
			Debug.LogWarning ("New instance of GameManager was prevented!");
			Destroy (gameObject);
			return;
		}
		Invoke ("resolveNewWave", FirstWaveDelayInSeconds);
	}

	void FixedUpdate() {
		if (unloadingOperation != null) {
			if (unloadingOperation.isDone) {
				unloadingOperation = null;
				Invoke ("resolveNewWave", nextWaveTimer);
			}
		}
	}

	void Update () {
		
	}

	void resolveNewWave() {
		int selected = wavesBuildIndex [Random.Range (0, wavesBuildIndex.Length)];
		SceneManager.LoadSceneAsync (selected, LoadSceneMode.Additive);
		waveId = selected;
	}

	public void notifyWaveEnded(Range _timeToNextWaveInSeconds) {
		unloadingOperation = SceneManager.UnloadSceneAsync (waveId);
		nextWaveTimer = _timeToNextWaveInSeconds.getFloat();
	}
}
