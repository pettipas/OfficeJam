using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireManager : MonoBehaviour {

	[SerializeField]
	protected GameOverManager gameOverManager;

	public static FireManager Instance;
	[SerializeField]
	protected ParticleSystem mainFire;
	[SerializeField]
	protected List<ParticleSystem> additionalFires;

	protected int lastEnabledFire;

	void Awake(){
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		lastEnabledFire = 0;
		Initialize ();
	}

	public void Initialize () {
		mainFire.enableEmission = true;
		foreach (ParticleSystem cps in mainFire.GetComponentsInChildren<ParticleSystem>()) {
			cps.enableEmission = true;
		}

		foreach (ParticleSystem ps in additionalFires) {
			ps.enableEmission = false;
			foreach (ParticleSystem cps in ps.GetComponentsInChildren<ParticleSystem>()) {
				cps.enableEmission = false;
			}
		}

		lastEnabledFire = 0;
	}
	
	public void EnableFire () {

		if (lastEnabledFire < additionalFires.Count) {

			// add it to the list of enabled fires
			additionalFires[lastEnabledFire].enableEmission = true;
			foreach (ParticleSystem cps in additionalFires[lastEnabledFire].GetComponentsInChildren<ParticleSystem>()) {
				cps.enableEmission = true;
			}
			lastEnabledFire++;
		}
	}

	public void DisableFire () {
		int counter = 3;
		while (counter > 0) {
			if (lastEnabledFire > 0) {
				additionalFires[lastEnabledFire].enableEmission = false;
				foreach (ParticleSystem cps in additionalFires[lastEnabledFire].GetComponentsInChildren<ParticleSystem>()) {
					cps.enableEmission = false;
				}
				lastEnabledFire--;

			} else {
				mainFire.enableEmission = false;
				foreach (ParticleSystem cps in mainFire.GetComponentsInChildren<ParticleSystem>()) {
					cps.enableEmission = false;
				}
				gameOverManager.EndGame ();
			}
			counter--;
		}

	}
}
